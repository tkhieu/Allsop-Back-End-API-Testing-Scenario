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
#### API
1. **Get Categories**
```
GET: http://localhost:5001/api/Categories
Headers
* Authorization: Bearer <Token>
```
Return
```
{
   "status":1,
   "message":"Success",
   "data":[
      {
         "id":"5beff28e-bba2-4b1b-9f06-126d6365d4cf",
         "name":"Meat & Poultry",
         "code":"MP"
      },
      {
         "id":"fd6055d7-08a3-4351-8195-7da47e50f028",
         "name":"Fruit & Vegetables",
         "code":"FV"
      },
      {
         "id":"737c9710-e069-436a-a236-660e8277dedf",
         "name":"Drinks",
         "code":"DR"
      },
      {
         "id":"bae52764-af07-4043-8586-52816594ee86",
         "name":"Confectionary & Desserts",
         "code":"CD"
      },
      {
         "id":"3786f39a-a229-4689-aed7-d851082cd87a",
         "name":"Baking/Cooking Ingredients",
         "code":"CI"
      },
      {
         "id":"b5901197-4899-4a22-ad39-7f1f4cdcb84b",
         "name":"Miscellaneous Items",
         "code":"MI"
      }
   ]
}
```
2. Get All Products
```
GET: http://localhost:5001/api/Products
Headers
* Authorization: Bearer <Token>
```
Example Return
```
{
   "status":1,
   "message":"Success",
   "data":[
      {
         "id":"48d5553e-a450-4523-a143-73263766b62b",
         "name":"Chicken Fillets",
         "packaging":"6 x 100g",
         "sku":"MP-000001",
         "category":{
            "id":"5beff28e-bba2-4b1b-9f06-126d6365d4cf",
            "name":"Meat & Poultry",
            "code":"MP"
         },
         "priceValue":4.5,
         "oldPriceValue":null,
         "priceUnit":"GBP",
         "inventoryQuantity":12
      }
   ]
}
```
3. **Get Products by Category Id**
```
GET: localhost:5001/api/Categories/:categoryId
Headers
* Authorization: Bearer <Token>
```
Example Return
```
{
   "status":1,
   "message":"Success",
   "data":[
      {
         "id":"48d5553e-a450-4523-a143-73263766b62b",
         "name":"Chicken Fillets",
         "packaging":"6 x 100g",
         "sku":"MP-000001",
         "category":{
            "id":"5beff28e-bba2-4b1b-9f06-126d6365d4cf",
            "name":"Meat & Poultry",
            "code":"MP"
         },
         "priceValue":4.5,
         "oldPriceValue":null,
         "priceUnit":"GBP",
         "inventoryQuantity":12
      }
   ]
}
```

### 3. Promotion Service
* Database using SQLite
### 4. Cart Service
* Database using SQLite
### 5. Ordering Service
TBD (To be developed)
### 6. Report Service
TBD (To be developed)
