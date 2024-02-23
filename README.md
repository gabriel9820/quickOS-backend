cd quickOS.Infra
dotnet ef --startup-project ../quickOS.API/ migrations add [name] --output-dir Persistence/Migrations
dotnet ef --startup-project ../quickOS.API/ database update