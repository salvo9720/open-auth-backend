@echo off


for %%F in (*.*) do if /I not "%%~xF"==".bat" del /q "%%F"

cd ..


echo Pulizia completata.

dotnet ef migrations add InitialCreate
echo creazione migrazione da EF dalle classi 

@echo off
set "ConnectionStrings__DefaultConnection=Host=localhost;Port=5432;Database=open-auth-db;Username=open-auth-user;Password=open-auth-psw"


dotnet ef database update
echo Database aggiornato correttamente.

pause