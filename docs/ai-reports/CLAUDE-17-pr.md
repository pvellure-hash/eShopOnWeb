# Upgrade Microsoft.AspNetCore.Components.WebAssembly.Server to 10.0.13

## Summary
Pins Microsoft.AspNetCore.Components.WebAssembly.Server at 10.0.13 to clear CVE-2026-96230 / GHSA-qjpx-jqm5-h2c4. The shared ASP.NET package property remains unchanged, so this ticket does not upgrade any other package.

## Validation
Reviewed the Web project package reference and Blazor framework call sites. The existing `AddServerSideBlazor` and `UseBlazorFrameworkFiles` usage requires no API changes. No source behavior changed, so no test was added. Local .NET commands were not run; pipeline validation must restore, build, run unit tests, and verify the vulnerability scan.

## Files changed
`Directory.Packages.props` and the required CLAUDE-17 report files under `docs/ai-reports/`.
