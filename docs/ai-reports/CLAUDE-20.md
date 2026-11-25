# CLAUDE-20 Solution Report

## Requirement and acceptance criteria
This dependency bug fix upgrades the production references to jquery-validation-unobtrusive 4.0.0 and keeps browser form validation loading. Both CDN URLs and their integrity hashes must match the new asset, no unrelated library should change, and the configured tests must pass.

## Root cause
The two production validation partials originally referenced 3.2.9 and 3.2.6 while `src/Web/libman.json` already selected 4.0.0 for local assets. After the CDN URLs were changed to 4.0.0, their integrity values remained for the previous assets, causing browsers to reject the CDN script.

## Changes made
Both production CDN references use 4.0.0 and now share the 4.0.0 SHA-384 integrity value verified against the ASP.NET Core 4.0.0 script reference. No other library, local script path, or fallback changed.

The validator correction was limited to replacing the stale integrity hashes; the browser rejects a resource when its supplied integrity value does not match the fetched script.

## Library upgrade review
Libraries: jquery-validation-unobtrusive 3.2.9 and 3.2.6 -> 4.0.0 (the ticket describes the prior version as 2.0).

Copies replaced: The two production CDN references now point to 4.0.0. The repository-wide search found no other older-version copy; `src/Web/libman.json` already specified 4.0.0.

Configuration changed: Both production CDN URLs target 4.0.0 and both SHA-384 integrity attributes match that asset. The LibMan declaration and local fallback paths remain unchanged.

Call sites reviewed:
- `src/Web/Areas/Identity/Pages/_ValidationScriptsPartial.cshtml`: CDN version and SRI hash corrected. This partial loads scripts but contains no direct unobtrusive-validation API calls, so no API migration was needed.
- `src/Web/Views/Shared/_ValidationScriptsPartial.cshtml`: CDN version and SRI hash corrected. This partial loads scripts but contains no direct unobtrusive-validation API calls, so no API migration was needed.

Tests added: None. These changes only correct external script URL/integrity metadata and add no application logic to unit-test. Local .NET tests cannot be run under repository instructions; the pipeline runs the configured unit tests and browser integrity validation.

Needs a person: No manual code change remains. The pipeline should confirm the browser integrity check and configured unit tests pass. No advisory ID or lock file was provided or identified.

## Files changed
- `src/Web/Areas/Identity/Pages/_ValidationScriptsPartial.cshtml`
- `src/Web/Views/Shared/_ValidationScriptsPartial.cshtml`
- `docs/ai-reports/CLAUDE-20.md`
- `docs/ai-reports/CLAUDE-20-pr.md`
- `docs/ai-reports/CLAUDE-20-jira.md`
- `docs/ai-reports/CLAUDE-20-solution-thinking.md`
- `docs/ai-reports/CLAUDE-20-implementation-thinking.md`
