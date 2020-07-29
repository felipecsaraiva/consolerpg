show events;

CREATE EVENT respawn_1
ON SCHEDULE EVERY 1 MINUTE
STARTS CURRENT_TIMESTAMP
do
	UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 1;

CREATE EVENT respawn_3
ON SCHEDULE EVERY 3 MINUTE
STARTS CURRENT_TIMESTAMP
do
	UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 3;
    
    
CREATE EVENT respawn_5
ON SCHEDULE EVERY 5 MINUTE
STARTS CURRENT_TIMESTAMP
do
	UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 5;
 

CREATE EVENT respawn_10
ON SCHEDULE EVERY 10 MINUTE
STARTS CURRENT_TIMESTAMP
do
	UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 10;
    
    
CREATE EVENT respawn_30
ON SCHEDULE EVERY 30 MINUTE
STARTS CURRENT_TIMESTAMP
do
	UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 30;


CREATE EVENT respawn_2h
ON SCHEDULE EVERY 2 HOUR
STARTS CURRENT_TIMESTAMP
do
	UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 2;    
    

CREATE EVENT respawn_12h
ON SCHEDULE EVERY 12 HOUR
STARTS CURRENT_TIMESTAMP
do
	UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 12;
    
CREATE EVENT respawn_d
ON SCHEDULE EVERY 1 DAY
STARTS CURRENT_TIMESTAMP
do
	UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 24;
        

CREATE EVENT heal
ON SCHEDULE EVERY 5 SECOND
STARTS current_timestamp
do
	UPDATE dbconsole.tb_personagem SET nr_hp = nr_hp + 2 WHERE nr_hp_max > nr_hp + 2 and st_descansando = 'N';
        
CREATE EVENT heal_max
ON SCHEDULE EVERY 5 SECOND
STARTS current_timestamp
do
	UPDATE dbconsole.tb_personagem SET nr_hp = nr_hp_max WHERE nr_hp_max <= nr_hp + 2 and st_descansando = 'N';
    

CREATE EVENT descanso
ON SCHEDULE EVERY 1 SECOND
STARTS current_timestamp
do
	UPDATE dbconsole.tb_personagem SET nr_hp = nr_hp + 10 WHERE nr_hp_max > nr_hp + 10 and st_descansando = 'S';
        
CREATE EVENT descanso_max
ON SCHEDULE EVERY 1 SECOND
STARTS current_timestamp
do
	UPDATE dbconsole.tb_personagem SET nr_hp = nr_hp_max WHERE nr_hp_max <= nr_hp + 10 and st_descansando = 'S';
    
CREATE EVENT remove_efeito
ON SCHEDULE EVERY 1 MINUTE
STARTS current_timestamp
do
	UPDATE dbconsole.tb_personagem SET nr_variavel = 0, id_tipoefeito = '', nr_contaefeito = 0 WHERE nr_contaefeito = 1;
     
CREATE EVENT remove_contador
ON SCHEDULE EVERY 1 MINUTE
STARTS current_timestamp
do
	UPDATE dbconsole.tb_personagem SET nr_contaefeito = nr_contaefeito - 1 WHERE nr_contaefeito > 1;
     