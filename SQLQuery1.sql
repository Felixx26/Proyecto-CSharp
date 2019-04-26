select l.id_libro, l.ISBN, l.titulo, e.editorial, p.pais, t.tipo, fecha_lanzamiento, edicion, idioma, paginas 
from Libro as l
inner join Editorial as e 
on l.id_editorial = e.id_editorial
inner join Pais as p
on l.id_pais = p.id_pais
inner join Tipo_libro as t
on l.id_tipo_libro = t.id_tipo_libro;

Select * from pais;

select l.id_libro, l.ISBN, l.titulo, e.editorial, p.pais, t.tipo, l.fecha_lanzamiento, l.edicion, l.idioma, l.paginas 
from Libro as l 
inner join Editorial as e on l.id_editorial = e.id_editorial 
inner join Pais as p on l.id_pais = p.id_pais 
inner join Tipo_libro as t on l.id_tipo_libro = t.id_tipo_libro
where e.editorial='PEARSON';

select * from Existencia;