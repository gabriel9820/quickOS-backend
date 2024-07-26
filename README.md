<h1 align="center">
  quickOS (backend)
</h1>

<p align="center">
  <img alt="Gabriel Alves" src="https://img.shields.io/badge/Developed%20by%3A-Gabriel Alves-%23DD3B3F" />
  <img alt="License" src="https://img.shields.io/github/license/gabriel9820/quickos-backend?label=License" />
  <img alt="C#" src="https://img.shields.io/badge/Main%20language-C%23-%23178600" />  
</p>

## :bookmark: Description

The project in question is a system for managing technical assistances, which works from registering customers, services, products and users to generating service orders and accounts payable/receivable. It was developed as a final project for my postgraduate degree in Full Stack Development at PUCRS.

<br />

## :heavy_check_mark: Table of Contents

- [:bookmark: Description](#bookmark-description)
- [:heavy\_check\_mark: Table of Contents](#heavy_check_mark-table-of-contents)
- [:bulb: Technologies](#bulb-technologies)
- [:computer: Demonstration](#computer-demonstration)
- [:wrench: Running the Project](#wrench-running-the-project)
- [:memo: License](#memo-license)
- [:wave: Social](#wave-social)

<br />

## :bulb: Technologies

- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/)
- [ASP.NET Core](https://docs.microsoft.com/pt-br/aspnet/core/)
- [Swagger](https://swagger.io/)
- [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)
- [QuestPDF](https://www.questpdf.com/)
- [Docker](https://docs.docker.com/)
- [PostgreSQL](https://www.postgresql.org/)
- [AWS Elastic Beanstalk](https://docs.aws.amazon.com/elastic-beanstalk/)
- [Amazon RDS](https://docs.aws.amazon.com/rds/)

<br />

## :computer: Demonstration

[<img alt="link" src="https://img.shields.io/badge/Demonstration-Link-blue">](https://main.d42mr3aptc73o.amplifyapp.com/login/)

<img alt="image1" src="https://i.imgur.com/5lW4jM0.png" />

<br />

## :wrench: Running the Project

<strong> Project </strong>

```bash
# Clone
$ git clone git@github.com:gabriel9820/quickOS-backend.git

# Navigate to the API directory
$ cd quickOS-backend/quickOS.API

# Run the project
$ dotnet run
```

<strong> Migrations </strong>

It's necessary to run the commands inside the directory `quickOS.Infra`

```bash
$ cd quickOS.Infra
```

Generate a migration:

```bash
$ dotnet ef --startup-project ../quickOS.API/ migrations add [name] --output-dir Persistence/Migrations
```

Run pending migrations:

```bash
$ dotnet ef --startup-project ../quickOS.API/ database update
```

Generate the scripts to run manually on the database:

```bash
# From the beginning
$ dotnet ef --startup-project ../quickOS.API/ migrations script

# From a specific migration
$ dotnet ef --startup-project ../quickOS.API/ migrations script [name]

# From a range of migrations
$ dotnet ef --startup-project ../quickOS.API/ migrations script [fromName] [toName]
```

<br />

## :memo: License

This project is under license [GPL-3.0](LICENSE).

<br />

## :wave: Social

[<img alt="LinkedIn" src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white">](https://www.linkedin.com/in/gabriel-lemos-alves/)

<br />
