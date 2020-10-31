# Docker API

[![RELEASE](https://img.shields.io/badge/version-v1.0.0-blue)](https://github.com/cesarrrguez/DockerAPI/releases/tag/v1.0.0)
[![LICENSE](https://img.shields.io/badge/license-MIT-green)](LICENSE)

_.NET Core Web API_ with _SQL Server_ connection using _Docker_ and _Docker Compose_.

## Requirements

- .Net Core
- Docker

## Usage

Run docker containers in background:

```console
docker-compose up -d
```

Build database from entity framework core migration:

```console
dotnet ef database update
```

## License

The MIT License (MIT). Please see [License](LICENSE) for more information.
