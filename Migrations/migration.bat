@echo off


for %%F in (*.*) do if /I not "%%~xF"==".bat" del /q "%%F"

cd ..


echo Pulizia completata.

dotnet ef migrations add InitialCreate
echo creazione migrazione da EF dalle classi 

dotnet ef database update
echo Database aggiornato correttamente.

pause