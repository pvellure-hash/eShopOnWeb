# CLAUDE-20 Solution Report

## Requirement and acceptance criteria
This is a dependency bug fix: update production references to jquery-validation-unobtrusive 4.0.0, retain form validation behavior, and avoid changing any other library. The acceptance criteria are that both active CDN references target 4.0.0, existing validation remains available, and the configured tests pass.

## Root cause
The two production validation partials referenced jquery-validation-unobtrusive 3.2.9 and 3.2.6, while `src/Web/libman.json` already selects 4.0.0 for the local assets.

## Changes made
Updated the CDN version path in both production script partials to 4.0.0. The Development/Docker script paths and every other library declaration remain unchanged. No advisory ID was provided.

## Library upgrade review
Libraries: jquery-validation-unobtrusive 3.2.9 and 3.2.6 -> 4.0.0 (the ticket describes the prior version as 2.0).

Copies replaced: The two production CDN references in the call sites below now use 4.0.0. The repository-wide search found no other old-version copy; `src/Web/libman.json` already specified 4.0.0.

Configuration changed: Both production CDN URLs now target 4.0.0. The LibMan declaration and local fallback paths were unchanged.

Call sites reviewed:
- `src/Web/Areas/Identity/Pages/_ValidationScriptsPartial.cshtml`: changed the CDN version path. This file only loads jQuery validation scripts and does not call unobtrusive-validation APIs.
- `src/Web/Views/Shared/_ValidationScriptsPartial.cshtml`: changed the CDN version path. This file only loads jQuery validation scripts and does not call unobtrusive-validation APIs.

Tests added: None. This is an asset URL/version-only dependency update, with no application behavior code to exercise; repository instructions prohibit local `dotnet` test runs. The pipeline should run the configured unit tests.

Needs a person: The release notes could not be retrieved in this environment, so confirm the 4.0.0 release changes and run the pipeline/browser validation. The existing per-version SRI hashes were left unchanged to honor the URL-only scope; verify and update each hash to the 4.0.0 asset's published hash before deployment if the CDN content differs. No lock file or restore command was identified as applicable.

## Files changed
- `src/Web/Areas/Identity/Pages/_ValidationScriptsPartial.cshtml`
- `src/Web/Views/Shared/_ValidationScriptsPartial.cshtml`
- `docs/ai-reports/CLAUDE-20.md`
- `docs/ai-reports/CLAUDE-20-pr.md`
- `docs/ai-reports/CLAUDE-20-jira.md`
- `docs/ai-reports/CLAUDE-20-solution-thinking.md`
- `docs/ai-reports/CLAUDE-20-implementation-thinking.md`
