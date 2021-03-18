
# Allsop-Back-End-API-Testing-Scenario


## Toolings

* [JetBrain Rider](https://www.jetbrains.com/rider/)
* [VSCode](https://code.visualstudio.com/) 

## Database
* SQLite

## Sourcode folders
![enter image description here](https://raw.githubusercontent.com/tkhieu/Allsop-Back-End-API-Testing-Scenario/add-assets/Assets/SourceCodeFolders.png)

1. **Common Project**
* Configuration: The global configurations for any services can use
* gRPC: The simple Abstract Factory to new a gRPC client without know the destination address
* Helpers: Some minor helpers to help encode/decode JWT and generate unique Coupon Code
* Middlewares: Holding the middlewares that intercept every request, for example JWT Middleware to decode and get User Id from JWT token
* Models: Share model accross services
* Protos: Share proto and generate necessary class to interactive with gRPC sevices
* Shared: Just holding `AppSettings` for now, will be merge to `Configuration`
* ViewModel: Common view models for API return

2. **Services Project** (in the screenshot is Cart Service)
* Controllers: Very basic folder to hold services controllers
* Infrastructure: Mainly for some important classes such as `DbContext`
* Migrations: Migraions script that generated from EF Core
* Repositories: Containt repository to interactive with db
* Services: Containt repository to manipulate data
* ViewModes: View models for API return

## System Design

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

#### API
1. **Create Discount Campaign Off 10% for Drink when buying 10 or more Drinks**
```
POST: http://localhost:5004/api/DiscountCampaigns
{
   "name":"Discount Campaign Off 10% for Drink when buying 10 or more Drinks",
   "codesAmount":10,
   "codeType":2,
   "codePrefix":"OFF10DRINK",
   "discountCampaignType":2,
   "discountValue":10,
   "discountCampaignApplyOn":3,
   "discountCampaignApplyOnId":"737c9710-e069-436a-a236-660e8277dedf",
   "startDate":"2021-01-01",
   "expirationDate":"2022-01-01",
   "discountValidations":[
      {
         "operator":1,
         "valueType":5,
         "value":"737c9710-e069-436a-a236-660e8277dedf"
      },
      {
         "operator":2,
         "valueType":2,
         "value":"10"
      }
   ]
}
```

2. **£5.00 off your order when spending £50.00 or more on Baking/Cooking Ingredients**
```
POST: http://localhost:5004/api/DiscountCampaigns
{
   "name":"£5.00 off your order when spending £50.00 or more on Baking/Cooking Ingredients",
   "codesAmount":10,
   "codeType":2,
   "codePrefix":"LESS50INGREDIENTS",
   "discountCampaignType":1,
   "discountValue":5,
   "discountCampaignApplyOn":1,
   "startDate":"2021-01-01",
   "expirationDate":"2022-01-01",
   "discountValidations":[
      {
         "operator":1,
         "valueType":5,
         "value":"3786f39a-a229-4689-aed7-d851082cd87a"
      },
      {
         "operator":2,
         "valueType":3,
         "value":"50"
      }
   ]
}
```
3. **£20.00 off your total order value when spending £100.00 or more and using the code "20OFFPROMO"**
```
POST: http://localhost:5004/api/DiscountCampaigns
{
   "name":"£20.00 off your total order value when spending £100.00 or more and using the code 20OFFPROMO",
   "codesAmount":10,
   "codeType":1,
   "maxRedeem":100,
   "singleCode":"20OFFPROMO",
   "discountCampaignType":1,
   "discountValue":20,
   "discountCampaignApplyOn":1,
   "startDate":"2021-01-01",
   "expirationDate":"2022-01-01",
   "discountValidations":[
      {
         "operator":2,
         "valueType":1,
         "value":"100"
      }
   ]
}
```

### 4. Cart Service
#### API
1. **Get My Cart**
```
GET: localhost:5002/api/Carts/Me
Headers
* Authorization: Bearer <Token>
```
2. **Insert Product To Cart**
```
POST: localhost:5002/api/Carts/Me
{
   "ProductId":"89090eed-5f8d-44bd-ac60-af45256c92ec",
   "Quantity":5
}
```
3. **Add Product To Cart**
```
PUT: localhost:5002/api/Carts/Me
{
   "ProductId":"89090eed-5f8d-44bd-ac60-af45256c92ec",
   "Quantity":5
}
```
4. **Delete Product From Cart**
```
DELETE: localhost:5002/api/Carts/Me
{
   "ProductId":"89090eed-5f8d-44bd-ac60-af45256c92ec"
}
```
5. **Empty Cart**
```
DELETE: localhost:5002/api/Carts/Me/EmptyCart
```
6. **Add Coupon Code**
```
POST: localhost:5002/api/Carts/Me/DiscountCode
{
   "discountCode":"LESS50INGREDIENTS-0MITX"
}
```

### 5. Ordering Service
TBD (To be developed)
### 6. Report Service
TBD (To be developed)
