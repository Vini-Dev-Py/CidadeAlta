FROM mysql:5.7.22
EXPOSE 3306

COPY ./CodigoPenalCDA/db/migrations/ /home/database/

COPY ./CodigoPenalCDA/db/dataset/ /home/database/

COPY ./CodigoPenalCDA/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh