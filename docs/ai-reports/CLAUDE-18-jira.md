Updated Microsoft.AspNetCore.Components.WebAssembly.Server from 10.0.13 to 10.0.14 for GHSA-g27p-qf6j-c96c, and Azure.Identity from 1.10.4 to 1.11.4 for GHSA-m5vv-6r4h-3vj9 and GHSA-wvxc-855f-jvrv. Both versions are centrally pinned in `Directory.Packages.props`; no other package or source call site changed.

No lock file was found. A person or the pipeline must run `dotnet restore --force-evaluate` and `dotnet list eShopOnWeb.sln package --vulnerable --include-transitive`. No unit or integration test was added because the dependency-only upgrades require no source behavior change.

PR: <PR link>
