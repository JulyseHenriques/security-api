-- Criar um novo usuário
CREATE ROLE "SECURITY_API" 
	NOSUPERUSER 
	NOCREATEDB 
	NOCREATEROLE 
	NOINHERIT 
	LOGIN 
	NOREPLICATION 
	NOBYPASSRLS 
	PASSWORD 'test123';

-- Conceder todas as permissões do banco de dados ao novo usuário
GRANT ALL ON SCHEMA public TO "SECURITY_API";
