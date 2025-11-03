#!/bin/bash
set -e

echo "Esperando a que SQL Server esté listo..."

# Esperar a que sqlcmd pueda conectarse
until /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -Q "SELECT 1" &> /dev/null
do
    echo "SQL Server no disponible todavía... esperando 5s"
    sleep 5
done

echo "SQL Server listo!"

# Ejecutar DDL
echo "Ejecutando DDL..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -d master -i /scripts/ddl_persona_db.sql

# Ejecutar DML
echo "Ejecutando DML..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -d persona_db -i /scripts/dml_persona_db.sql

echo "Base de datos inicializada correctamente"
