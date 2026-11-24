Updated jQuery from 3.6.3 to 4.1.0 in the LibMan declaration and updated the production layout CDN reference, which previously loaded 2.2.0. No other library was changed.

The ignored vendor payload was not replaced. A person must run `libman restore src\Web`, then verify the pipeline tests and page behavior with the existing Bootstrap and validation scripts.

PR: <PR link>
