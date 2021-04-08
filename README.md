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
        <li>Cache Aspect</li>
      </ul>
      <ul>
        <li>Transaction Aspect</li>
      </ul>
      <ul>
        <li>Performance Aspect</li>
      </ul>
      <ul>
        <li>Validation Aspect(Fluent Validation)</li>
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
      <ul>
        <li>SOLID</li>
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
</br>
[![TypeScript](https://img.shields.io/badge/TypeScript-007ACC?style=for-the-badge&logo=typescript&logoColor=white)](https://www.typescriptlang.org/)
[![Angular](https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white)](https://angular.io/)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)](https://getbootstrap.com/docs/)

## Models

### Cars

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

We write our workloads on this layer. This layer is the layer that will process the data that has been pulled into the project by Data Access. We do not use the Data Access layer directly in our applications. By putting the Business layer together, we make Business do it for us. The data from the user first goes to the Business layer, and then is processed and transferred to the Data Access layer. In the business tier, we also specify who will access this data. For example, there is R&D and HR section. We want the R&D department to add to the database, but if we want the HR department to only pull the data, we do this in the Business Layer.

### Core

In this layer, we have base classes that all projects can use in common.

### DataAccess

Only database operations are performed in this layer. The task of this layer is to add, delete, update and extract data from the database. No other action is taken in this layer other than these operations.

### Entities

In this layer, we determine our main classes that we will use throughout the project, so this is where we determine our real objects. Here, we match the objects we have determined with the objects registered in the database.

### WebAPI

Web API Layer that opens the business layer to the internet.

</details>
<p></p>

## Türkçe Açıklama

 ### Proje SOLID, Kurumsal Yazılım Mimari, AOP ve Yazılım Geliştirme Prensiplerine uygun geliştirildi.
 
* .Net Core 3.1 platformu ile geliştirildi.
* **Cross Cutting Concerns** "kesişen ilgililer" **interceptor *Autofac** kütüphanesi kullanılarak geliştirildi.
  * Performance   
  * Transaction
  * Validation
  * Caching

* Entity Framework ORM kullanılarak geliştirildi.
* **AOP** ile **Cross Cutting Concerns** "kesişen ilgililer" projede modülarite yapıda geliştirildi. 
* **Exception Middleware** ile Merkezi hata mekanizması geliştrildi.
* **Claim** Mekanizması ile rol bazlı yetkilendirmenin sınırları esnetildi.
* **JWT (JSON Web Token)** kimlik doğrulaması entegre edildi.
* **Fluent Validation** ile validasyon(doğrulama) işlemleri geliştirildi.
* **IoC(Inversion Of Control)** ile (loose coupling) olan nesneler oluşturuldu.
* **REST VE RESTFUL WEB SERVİS** ile sunucu-istemci iletişimi sağlandı.

### C# Backend Katmanlar

* **Core**: Toolların diğer projelerde kullanılmasını sağlayan genel bir katmandır. 
* **Entities**: Veritabanındaki tabloları nesneye dönüştürdüğümüz katman.
* **DataAccess**: Veritabanı işlemlerini yaptığımız katman.
* **Business**:İş kurallarımızı geliştirdiğimiz katman.
* **WebAPI**: Restful (Representational State Transfer) HTTP protokolü ile sunucu-istemci iletişimi sağladığımız katman. 




## Contact

Semih Şahan - [semihshn.rf.gd](http://semihshn.rf.gd/)

Linkedin - [Linkedin](https://www.linkedin.com/in/semih-%C5%9Fahan-8a7627176/)

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
