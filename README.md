## Migrations

É necessário rodar os comandos dentro do diretório `quickOS.Infra`

```bash
cd quickOS.Infra
```

Gerar uma migration:

```bash
dotnet ef --startup-project ../quickOS.API/ migrations add [name] --output-dir Persistence/Migrations
```

Rodar as migrations pendentes:

```bash
dotnet ef --startup-project ../quickOS.API/ database update
```

Gerar os scripts para rodar manualmente no banco de dados:

```bash
# Desde o início
dotnet ef --startup-project ../quickOS.API/ migrations script

# De uma migration específica
dotnet ef --startup-project ../quickOS.API/ migrations script [name]

# De um intervalo de migrations
dotnet ef --startup-project ../quickOS.API/ migrations script [fromName] [toName]
```
