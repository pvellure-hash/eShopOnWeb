# CLAUDE-19 Solution Report

## Requirement and acceptance criteria
This is a dependency bug fix: update jQuery from 3.6.3 to 4.1.0, replace all active old-version references, preserve page behavior, and avoid changing any other library.

## Root cause
`src/Web/libman.json` declared jQuery 3.6.3 for local assets, while the production CDN reference in `src/Web/Views/Shared/_Layout.cshtml` separately loaded jQuery 2.2.0. The checked-in vendor payload under `src/Web/wwwroot/lib/jquery/` is ignored and could not be replaced in this task.

## Change made
Updated the LibMan declaration to `jquery@4.1.0` and the production CDN URL to `jquery-4.1.0.min.js`. No other library or asset path was changed.

## Library upgrade review
Libraries: jQuery 3.6.3 -> 4.1.0; the production CDN reference previously used jQuery 2.2.0.

Copies replaced: The LibMan declaration and production CDN reference were updated. The ignored vendor files under `src/Web/wwwroot/lib/jquery/` were not replaced.

Configuration changed: `src/Web/libman.json` now selects jQuery 4.1.0; `_Layout.cshtml` requests jQuery 4.1.0 in Staging and Production. Bootstrap and validation library declarations were unchanged.

Call sites reviewed:
- `src/Web/Areas/Identity/Pages/_ValidationScriptsPartial.cshtml`: no change needed; it loads jquery-validation and unobtrusive validation and contains no direct jQuery API calls.
- `src/Web/Views/Shared/_ValidationScriptsPartial.cshtml`: no change needed; it loads jquery-validation and unobtrusive validation and contains no direct jQuery API calls.
- `src/Web/Views/Shared/_Layout.cshtml`: changed the production jQuery URL; the view contains no direct jQuery API calls, and no removed jQuery API use was found in the application `wwwroot/js` source.

Tests added: None. This changes asset-version declarations only; it adds no application logic or call-site behavior for a unit test to exercise. Local .NET tests were not run because repository instructions prohibit `dotnet` commands.

Needs a person: The ignored vendor files were not updated. From the repository root, run `libman restore src\Web` to restore the 4.1.0 assets. Then verify the pipeline build/tests and check Staging/Production behavior, including the existing Bootstrap and validation scripts, with jQuery 4.1.0. No advisory ID was supplied in the task.

## Files changed
- `src/Web/libman.json`
- `src/Web/Views/Shared/_Layout.cshtml`
- `docs/ai-reports/CLAUDE-19.md`
- `docs/ai-reports/CLAUDE-19-pr.md`
- `docs/ai-reports/CLAUDE-19-jira.md`
- `docs/ai-reports/CLAUDE-19-solution-thinking.md`
- `docs/ai-reports/CLAUDE-19-implementation-thinking.md`

## Remaining work
The ignored vendor assets must be restored by a person, and the pipeline must confirm the upgraded assets work with existing downstream scripts. No tests were run locally.
