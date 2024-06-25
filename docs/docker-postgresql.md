## Syntax to Import Data into Container Using Backup File

### Basic Steps to Copy Existing Data to PostgreSQL Container

1. **Run PostgreSQL Container:**
   ```sh
   docker run --name <container-name> -e POSTGRES_PASSWORD=<your-password> -d postgres
   ```
2. **Connect to PostgreSQL Container:**
   ```sh
   docker exec -it <container-name> psql -U postgres
   ```
3. **Create New Database:**
   ```sql
   CREATE DATABASE <database-name>;
   ```
4. **Copy Backup File to PostgreSQL Container:**

   ```sh
   docker cp <path-to-your-file-backup> <container-name>:/var/lib/postgresql/data/<file-backup>
   ```

5. **Execute SQL File in PostgreSQL Container:**
   ```sh
   docker exec -it <container-name> psql -U postgres -d <database-name> -f /var/lib/postgresql/data/<file-backup>
   ```

### Detailed Steps:

1. **Run PostgreSQL Container:**

   - Use the `docker run` command to start a new PostgreSQL container.
   - Replace `<container-name>` with your desired container name.
   - Set the PostgreSQL password by replacing `<your-password>`.

2. **Connect to PostgreSQL Container:**

   - Use the `docker exec` command to connect to the running container.
   - This opens a psql session as the `postgres` user.

3. **Create New Database:**

   - Once connected, create a new database using the `CREATE DATABASE` SQL command.
   - Replace `<database-name>` with the name of your new database.

4. **Copy Backup File to PostgreSQL Container:**

   - Use the `docker cp` command to copy your backup file from the host to the container.
   - Replace `<path-to-your-file-backup>` with the path to your backup file on the host.
   - Replace `<file-backup>` with the name you want to give the file inside the container.

5. **Execute SQL File in PostgreSQL Container:**
   - Use the `docker exec` command to execute the SQL file inside the container.
   - Replace `<database-name>` with the name of the database you created.
   - Replace `<file-backup>` with the name of the SQL file you copied to the container.

Following these steps will allow you to import data from a backup file into a PostgreSQL container efficiently.
