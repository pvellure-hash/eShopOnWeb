# Upgrade jquery-validation-unobtrusive to 4.0.0

## Summary
Updated the production CDN references in the Identity and shared validation script partials from 3.2.9 and 3.2.6 to 4.0.0. The local LibMan declaration already selected 4.0.0, and no other library was changed.

## Validation
Searched the repository for jquery-validation-unobtrusive and its script filename; only the two named CDN references contained the older versions. Both partials only load validation scripts and have no direct API calls. No test was added for this version-only URL change, and local .NET test execution is prohibited by repository instructions. The release notes could not be retrieved here. Verify the existing SRI hashes against the 4.0.0 asset and run pipeline/browser validation before deployment.

## Files changed
The two validation partials and the required CLAUDE-20 reports under `docs/ai-reports/`.
