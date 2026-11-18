# Upgrade System.Text.Json to 8.0.5

## Summary
Updates the centrally managed `System.Text.Json` version from 8.0.3 to 8.0.5 to address CVE-2024-30105, CVE-2024-43485, and GHSA-8G4Q-XG66-9FP4.

## Validation
No application or test source files changed; the existing serialization call sites remain unchanged. Local .NET commands were not run because repository instructions prohibit them. Pipeline validation should run the configured build and tests and verify the vulnerability scan no longer reports the advisories.

## Files changed
`Directory.Packages.props` and the required CLAUDE-9 reports under `docs/ai-reports/`.
