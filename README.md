The Web API project provides API’s for various actions to manage the inventory for Apparels.

Entity Framework is used to manage the database connection. (InventoryApiDbContext.cs)

Also for development purpose and local testing, seed data is added which will give test data for products.(File Name: SeedData.cs)

The Service folder contains Service classes acting as middleware between DBContext and Controllers.

The Infrastructure folder contains Mapping class to map entity classes with models.

The filters folder include below 2 files:
1.	JsonExceptionFilter.cs :- Inherited from IExceptionFilter which will handle the error handling logic and simplifies error message as per environment(ApiError.cs)
2.	RequireHttpsOrCloseAttribue.cs  : - Inherited from RequireHttpsAttribute which adds security and prevents calls from http and allows only https calls

Functionalities Added-
•	Get All Products
o	GET https://localhost:XXXXX/Product

•	Get Product By ID(GUID)
o	GET https://localhost:XXXXX/Product/9befa2ed-a839-491f-ad48-191b8ff13923

•	Post New Product
o	POST https://localhost:XXXXX/product/post
Body attribute- JSON Form data for product
e.g. {
    "Name" : "Dhoti",
    "Color" : "Pink",
    "UnitPrice" : "750",
    "Category" : "Mens",
    "Quantity" : 200
}

•	Update existing product
o	PUT https://localhost:XXXXX/product/add
Body attribute – JSON form data
e.g {
    "ProductId":"5d1bfa94-8d97-421e-9b84-16cc65bd69db",
    "Quantity":5
}

•	Delete Product(Soft Delete)(GUID)
o	DELETE https://localhost:XXXXX/Product/9befa2ed-a839-491f-ad48-191b8ff13923
Updates the flag Isdeleted to true
To implement soft delete -Overridden the method SaveChangesAsync in Dbcontext which will update the entry and state in ChangeTracker.





