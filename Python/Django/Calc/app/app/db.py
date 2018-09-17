import sqlite3

create_table = 'create table test (id integer, txt varchar(50);'
conn = sqlite3.connect('example.db')
c = conn.cursor()
c.execute(create_table)
c.execute("")
c.close()
conn.commit()
conn.close()