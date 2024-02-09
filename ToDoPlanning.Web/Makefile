.PHONY: ToDoPlanning
 
MIGRATION_NAME = $(shell date "+%Y%m%d%H%M%S")
WEB_PROJECT_PATH = ../ToDoPlanning.Web
DATA_PROJECT_PATH= ../ToDoPlanning.Data

create-migration:
	cd $(DATA_PROJECT_PATH) && dotnet ef migrations add $(MIGRATION_NAME) --startup-project $(WEB_PROJECT_PATH)

update-database:
	dotnet ef database update

update-migration:
	dotnet ef update
run-console:
	cd ../ToDoPlanning.Console && dotnet run

database-setup:
	docker-compose up -d

run-web:
	dotnet run

