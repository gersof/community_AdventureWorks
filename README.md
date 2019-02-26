# community_AdventureWorks

Installing sql server on docker container with adventureworks database

#pull the sql server container from docker.

#sudo docker pull mcr.microsoft.com/mssql/server:2017-latest

#run the container

#docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=<YourStrong!Passw0rd>' -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2017-latest

#check if the container is running

#docker ps

#Change the password of your database

#connect to the database using sql server management studio

#use the following command

#ALTER LOGIN SA WITH PASSWORD='NewPassword'

#download the adventureworks database 

#Restore the database

#create a folder inside the container where the backup is going to be placed

#docker exec -it sql1 mkdir /var/opt/mssql/backup

#navigate where you downloaded the adventureworks backup

#copy the backup in the backup folder of your docker container

#docker cp AdventureWorks2017.bak sql1:/var/opt/mssql/backup

#Then you can restore your database using SQL Server Management studio
