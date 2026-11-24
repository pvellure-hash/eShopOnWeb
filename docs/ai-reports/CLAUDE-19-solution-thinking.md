# CLAUDE-19 Solution Thinking

## Requirement classification
This is a bug fix for outdated and inconsistent jQuery versions, not a feature request.

## Acceptance criteria
The Web project should use jQuery 4.1.0, no active reference should continue to select the old version, page behavior should remain intact, and no other library should change.

## Assumptions
The task's specified version 4.1.0 is the target. The LibMan manifest and production CDN reference are the version declarations to update. The ignored vendor payload must be restored by a person because it cannot be committed from this worktree.

## Root cause
`src/Web/libman.json` selected jQuery 3.6.3, while the production layout's CDN URL pointed to jQuery 2.2.0. The checked-in library directory is ignored, so its downloaded files could not be replaced here.

## Planned correction
Update only those two version strings, review the three script-loading views for removed jQuery API usage, and document the vendor restore and validation needed from a person.

## Result
The LibMan and production CDN version strings now specify 4.1.0. The three script partials contain no direct jQuery API use, and no removed jQuery API use was found in the application JavaScript sources. No non-jQuery library was changed.

## Validation limits
No tests were added because no application logic changed, and local .NET commands are prohibited by repository instructions. A person must restore LibMan assets and the pipeline must verify that the existing Bootstrap and validation scripts behave with jQuery 4.1.0.
