//�������� ��������
dotnet ef migrations add InitialCreate --context PromoCodeFactoryContext

//���������� ���� ������. ���������� � ������� Customers
dotnet ef migrations add AddCustomerBirthDay --context PromoCodeFactoryContext

//���������� ��������
dotnet ef database update --context PromoCodeFactoryContext

//����� ��������
dotnet ef database update InitialCreate --context PromoCodeFactoryContext

//�������� ��������
dotnet ef migrations remove --context PromoCodeFactoryContext
