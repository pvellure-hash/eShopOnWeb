# Upgrade jquery-validation to 1.21.0

## Summary
Updates the LibMan jquery-validation dependency from 1.19.5 to 1.21.0 for CVE-2025-3573 / GHSA-rrj2-ph5q-jxw2. Both shared and Identity validation partials now load the configured local library in every environment instead of older CDN releases.

## Validation
Reviewed all jquery-validation references and partial usages. No JavaScript test harness is present; local .NET commands were not run because repository instructions prohibit them. Pipeline validation should verify asset restoration, configured tests, and the vulnerability scan.

## Files changed
`src/Web/libman.json`, both `_ValidationScriptsPartial.cshtml` files, and the required CLAUDE-10 reports under `docs/ai-reports/`.
