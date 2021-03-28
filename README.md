[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<br />
<p align="center">
  <a href="https://github.com/semihshn/RentaCar-Back-end">
    <img src="https://www.car2go.com/media/data/demo/images/171109_gla_cla_800x600_-2x_502.jpg">
  </a>
  <h2 align="center">ReCapProject</h2>
  <p align="center">
    Car Rental project with N-Layer Architecture.    
  </p>
</p>

<br />
<br />
    <p align="center">
    In this project, we created a website for car rental using Asp.net Web API + Angular, in fact, we created a platform for the car rental industry, car rental companies will be able to register on our site and reach more customers, customers will be able to rent a car at a cheaper price.
    </p>

<details open="open">
  <summary><strong>Techs</strong></summary>
  <ol>
    <li>
      <a href="https://github.com/semihshn/RentaCar-Back-end/tree/master/ReCapProject">Back-End</a>
      <ul>
        <li>Restful Web Api Vers. .Net Core 3.1</li>
      </ul>
      <ul>
        <li>Multi-Layer Architecture</li>
      </ul>
      <ul>
        <li>Interceptor</li>
      </ul>
      <ul>
        <li>Aspects</li>
      </ul>
      <ul>
        <li>Cache Managment</li>
      </ul>
      <ul>
        <li>Fluent Validation</li>
      </ul>
      <ul>
        <li>Authorization</li>
      </ul>
      <ul>
        <li>Authentication</li>
      </ul>
      <ul>
        <li>Autofac</li>
      </ul>
      <ul>
        <li>Json Web Token Managment</li>
      </ul>
      <ul>
        <li>Async Programing</li>
      </ul>
      <ul>
        <li>Cross Cutting Concerns</li>
      </ul>
      
   </li>
    <li>
    <a href="https://github.com/semihshn/RentaCar-Front-End">Front-End</a>
      <ul>
        <li>Angular 11</li>
      </ul>
      <ul>
        <li>Bootstrap 5.0</li>
      </ul>
      <ul>
        <li>HttpClient Interceptor</li>
      </ul>
      <ul>
        <li>Guards</li>
      </ul>
      <ul>
        <li>Pipes</li>
      </ul>
      <ul>
        <li>Directives</li>
      </ul>
    </li>
  </ol>
</details>

## About The Project

### Built With

[![C-Sharp](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Asp-net](https://img.shields.io/badge/ASP.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet)
[![MSSQL](https://img.shields.io/badge/MSSQL-004880?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server/sql-server-2019?rtc=2)
[![Entity-Framework](https://img.shields.io/badge/Entity%20Framework-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://docs.microsoft.com/en-us/ef/)
[![Autofac](https://img.shields.io/badge/Autofac-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://autofac.org/)
[![Fluent-Validation](https://img.shields.io/badge/Fluent%20Validation-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://fluentvalidation.net/)
[![Angular 11](https://angular.io/assets/images/logos/angular/logo-nav@2x.png)](http://angular.io/)
[![Bootstrap 5.0](https://angular.io/assets/images/logos/angular/logo-nav@2x.png)](http://angular.io/)
https://getbootstrap.com/

## Usage

## Models

### User

| Name        | Data Type     | Allow Nulls | Default |
| :---------- | :------------ | :---------- | :------ |
| Id          | int           | False       |         |
| Name        | nvarchar(50)  | False       |         |
| BrandId     | int           | False       |         |
| ColorId     | int           | False       |         |
| ModelId     | int           | False       |         |
| DailyPrice  | decimal(18,0) | False       |         |
| ModelYear   | smallint      | False       |         |
| Description | nvarchar(50)  | True        |         |

### Car Images

| Name      | Data Type     | Allow Nulls | Default |
| :-------- | :------------ | :---------- | :------ |
| Id        | int           | False       |         |
| CarId     | int           | False       |         |
| ImagePath | nvarchar(MAX) | False       |         |
| Date      | datetime      | False       |         |

## Brands

| Name | Data Type    | Allow Nulls | Default |
| :--- | :----------- | :---------- | :------ |
| Id   | int          | False       |         |
| Name | nvarchar(25) | False       |         |

## Models

| Name | Data Type    | Allow Nulls | Default |
| :--- | :----------- | :---------- | :------ |
| Id   | int          | False       |         |
| Name | nvarchar(25) | False       |         |

## Color

| Name | Data Type    | Allow Nulls | Default |
| :--- | :----------- | :---------- | :------ |
| Id   | int          | False       |         |
| Name | nvarchar(25) | False       |         |

## Customer

| Name        | Data Type | Allow Nulls | Default |
| :---------- | :-------- | :---------- | :------ |
| Id          | int       | False       |         |
| UserId      | int       | False       |         |
| CompanyName | nchar(50) | True        |         |

## Rental

| Name       | Data Type | Allow Nulls | Default |
| :--------- | :-------- | :---------- | :------ |
| Id         | int       | False       |         |
| CarId      | int       | False       |         |
| CustomerId | int       | False       |         |
| RentDate   | datetime  | True        |         |
| ReturnDate | datetime  | True        |         |

## Users

| Name         | Data Type      | Allow Nulls | Default |
| :----------- | :------------- | :---------- | :------ |
| Id           | int            | False       |         |
| FirstName    | nvarchar(50)   | False       |         |
| LastName     | nvarchar(50)   | False       |         |
| Email        | nvarchar(50)   | False       |         |
| PasswordHash | varbinary(500) | False       |         |
| PasswordSalt | varbinary(500) | False       |         |
| Status       | bit            | False       |         |

## OperationClaims

| Name | Data Type    | Allow Nulls | Default |
| :--- | :----------- | :---------- | :------ |
| Id   | int          | False       |         |
| Name | varchar(250) | False       |         |

## UserOperationClaims

| Name             | Data Type | Allow Nulls | Default |
| :--------------- | :-------- | :---------- | :------ |
| Id               | int       | False       |         |
| UserId           | int       | False       |         |
| OperationClaimId | int       | False       |         |

## Layers

### Business

Business Layer created to process or control the incoming information according to the required conditions.

### Core

Core layer containing various particles independent of the project.

### DataAccess

Data Access Layer created to perform database CRUD operations.

### Entities

Entities Layer created for database tables.

### WebAPI

Web API Layer that opens the business layer to the internet.

</details>
<p></p>

## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## Contact

Semih Şahan - [semihshn.rf.gd](http://semihshn.rf.gd/)

Project Link: [https://github.com/semihshn/RentaCar-Back-end](https://github.com/semihshn/RentaCar-Back-end)

## Acknowledgements

- engindemirog

[contributors-shield]: https://img.shields.io/github/contributors/semihshn/RentaCar-Back-end.svg?style=for-the-badge
[contributors-url]: https://github.com/semihshn/RentaCar-Back-end/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/semihshn/RentaCar-Back-end.svg?style=for-the-badge
[forks-url]: https://github.com/semihshn/RentaCar-Back-end/network/members
[stars-shield]: https://img.shields.io/github/stars/semihshn/RentaCar-Back-end.svg?style=for-the-badge
[stars-url]: https://github.com/semihshn/RentaCar-Back-end/stargazers
[issues-shield]: https://img.shields.io/github/issues/semihshn/RentaCar-Back-end.svg?style=for-the-badge
[issues-url]: https://github.com/semihshn/RentaCar-Back-end/issues
[license-shield]: https://img.shields.io/github/license/semihshn/RentaCar-Back-end.svg?style=for-the-badge
[license-url]: https://github.com/semihshn/RentaCar-Back-end
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/semih-%C5%9Fahan-8a7627176/
