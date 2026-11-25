# Upgrade jquery-validation-unobtrusive to 4.0.0

## Summary
Updated both production validation script partials to use jquery-validation-unobtrusive 4.0.0 and corrected their SHA-384 integrity values to match the new CDN asset. No other library or local fallback was changed.

## Validation
The repository-wide search found no other outdated CDN version; LibMan already selects 4.0.0. Both script partials only load validation scripts and have no direct calls to the unobtrusive-validation API, so no API migration was needed. No unit test was added for this asset metadata correction, and repository instructions prohibit local `dotnet` test runs. Pipeline unit tests and browser integrity validation remain to be run.

## Files changed
Both validation partials and the required CLAUDE-20 reports under `docs/ai-reports/`.
