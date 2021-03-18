## Allsop-Back-End-API-Testing-Scenario


## A. Toolings

* [JetBrain Rider](https://www.jetbrains.com/rider/)
* [VSCode](https://code.visualstudio.com/) 

## B. Database
* SQLite

## C. System Design

* Microservices
* Inter communication using gRPC

![System Services](https://raw.githubusercontent.com/tkhieu/Allsop-Back-End-API-Testing-Scenario/add-assets/Assets/Assets.jpg)

### 1. Identity Service
* ASP.NET Core Identity
* Database using SQLite
#### API
1. **Account Register**
```
POST: localhost:5000/api/account/register
{
   "username":"SSSSStringc",
   "email":"aaaaAAAser@example.comc",
   "password":"String@1",
   "confirmPassword":"String@1"
}
```
**Return 1:** User already exists
```
{
   "status":0,
   "message":"User already exists",
   "data":null
}
```
**Return 2:** Success

```
{
   "status":1,
   "message":"User created",
   "data":{
      "id":"2dfbf135-bcc7-423a-8ba8-e09fab6d452a",
      "userName":"kimhieu",
      "normalizedUserName":"KIMHIEU",
      "email":"tr.kimhieu@gmail.com",
      "normalizedEmail":"TR.KIMHIEU@GMAIL.COM",
      "emailConfirmed":false
   }
}
```
2. **Account Authenticate** 
```
POST: localhost:5000/api/Accounts/Authenticate
{
   "email":"aaaaAAAser@example.comc",
   "password":"String@1"
}
```
**Return 1:** Success
```
{
   "status":1,
   "message":"Authenticate success",
   "data":{
      "id":"b0f16e51-67f4-41ce-b545-aa55a311f3bc",
      "userName":"SSSSStringc",
      "email":"aaaaAAAser@example.comc",
      "token":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6ImIwZjE2ZTUxLTY3ZjQtNDFjZS1iNTQ1LWFhNTVhMzExZjNiYyIsIm5iZiI6MTYxNjA1NjYxMiwiZXhwIjoxNjE4NjQ4NjEyLCJpYXQiOjE2MTYwNTY2MTJ9.TUz_KDIS47Kw5QL1vIBTdV_iyDqp7K2wle_JsaSa090"
   }
}
```

### 2. Catalog Service
* Database using SQLite
### 3. Promotion Service
* Database using SQLite
### 4. Cart Service
* Database using SQLite
### 5. Ordering Service
TBD (To be developed)
### 6. Report Service
TBD (To be developed)
