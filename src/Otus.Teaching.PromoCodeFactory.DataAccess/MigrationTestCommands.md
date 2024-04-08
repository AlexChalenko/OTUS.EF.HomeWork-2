//создание миграции
dotnet ef migrations add InitialCreate --context PromoCodeFactoryContext

//обновление базы данных. добавление в таблице Customers
dotnet ef migrations add AddCustomerBirthDay --context PromoCodeFactoryContext

//применение миграции
dotnet ef database update --context PromoCodeFactoryContext

//откат миграции
dotnet ef database update InitialCreate --context PromoCodeFactoryContext

//удаление миграции
dotnet ef migrations remove --context PromoCodeFactoryContext
