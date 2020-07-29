UPDATE tb_area SET tx_comandos = CONCAT(CASE WHEN id_norte > 0 THEN '.n/' ELSE '' END,
CASE WHEN id_sul > 0 THEN '.s/' ELSE '' END,
CASE WHEN id_leste > 0 THEN '.l/' ELSE '' END,
CASE WHEN id_oeste > 0 THEN '.o/' ELSE '' END,
CASE WHEN id_loja > 0 THEN '.li/.c/.ve/' ELSE '' END,
CASE WHEN id_estalagem > 0 THEN '.desc/' ELSE '' END,
CASE WHEN id_ferreiro > 0 THEN '.forja/.fj/' ELSE '' END,
CASE WHEN id_alquimista > 0 THEN '.alquimia/.al/' ELSE '' END,
CASE WHEN id_deposito > 0 THEN '.buscar/.pegar/.guardar/' ELSE '' END)

                                
                                
                                
				