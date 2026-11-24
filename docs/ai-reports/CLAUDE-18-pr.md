# Upgrade two vulnerable Web dependencies

## Summary
Upgrade Microsoft.AspNetCore.Components.WebAssembly.Server from 10.0.13 to 10.0.14 and Azure.Identity from 1.10.4 to 1.11.4. The changes address GHSA-g27p-qf6j-c96c, GHSA-m5vv-6r4h-3vj9, and GHSA-wvxc-855f-jvrv without changing another package.

## Validation
Reviewed `src/Web/Program.cs` for Azure credential construction and existing Blazor startup calls. Both upgrades are API-compatible with the reviewed call sites, so no source change or behavior-test change is needed.

## Files changed
`Directory.Packages.props` and the required CLAUDE-18 report files under `docs/ai-reports/`.
