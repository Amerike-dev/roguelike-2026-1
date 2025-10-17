# Dungeon base

## Tamaños del dungeon

En esta sección se define el tamaño de los dungeon utilizando de referencia el Grid del mapa isometrico.

- **Pequeño**: 15 x 15
- **Mediano tipo 1**: 15 x 20
- **Mediano tipo 2**: 20 x 15
- **Mediano tipo 3**: 20 x 20
- **Grande**: 30 x 30 

## Escenarios y apariciones

### Escenarios Pasivos

- Tienda:
    - Tamaño: Pequeño
    - Probabilidad: 35%
    - Número de enemigos: 0
    - Distribución: Forma cuadrangular con la tienda en el centro y 3 mesas con los *items*, al rededor únicamente deben de haber grids de suelo normal.

- Bendición de la Antartida:
    - Tamaño: Mediano tipo 3
    - Probabilidad: 10%
    - Número de enemigos: 0
    - Distribución: El monolito de la ***Bendición de la Antartida*** debe estar paralela a la entrada de la sala. A su alrededor no debe de haber suelo y lo único que conecta el monolito con la entrada es un pasillo. 

- Aldea pinguina:
    - Tamaño: Pequeño - Mediano tipo 3
    - Probabilidad: 10%
    - Número de enemigos: 0
    - Distribución: Alde de pinguinos con al menos 3 casas colocadas al azar, no debe interferir con la entrada y salida de la sala. A los bordes o en el centro de la aldea debe de haber un lago que permita al pinguino recuperar *humedad*

### Escenarios con enemigos

- Frente de ataque:
    - Tamaño: Mediano tipo 1 o 2
    - Probabilidad: 80%
    - Número de enemigos: 15 - 20
    - Distribución: Deben haber muros que pasen en el medio del escenario en forma de rayo con una o dos casillas que dejen al jugador caminar. En el interior del rayo deben haber casillas de hielo.

- En la yanura:
    - Tamaño: Mediano tipo 1 o 3
    - Probabilidad: 65%
    - Número de enemigos: 20 - 30
    - Distribución: Deben haber varios tiles que formen pequeños lagos, que se posicionen mayormente en los bordes y se conecten entre si.

- La costa: 
    - Tamaño: Mediano tipo 2
    - Probabilidad: 40%
    - Número de enemigos: 20 - 30
    - Distribución: Tiles puestos al azar de suelo normal, hielo y agua. Los cuerpos de agua deben ser al menos *2 x 2*.

- Recinto de Morosov:
    - Tamaño: Grande
    - Probabilidad: ***Habitacion del jefe***
    - Número de enemigos: +40
    - Distribución: Paralelo a la entrada a la sala debe haber tiles de agua aludiendo a la salida al mar. La mayor parte del suelo debe ser de hielo. Pueden haber tiles de hielo sobre el agua haciendo alución a los icebergs.

## Items

- **Trozo de bacalao**: Recuperas *un tercio de humedad*.

- **Pez dragon pequeño**: Recuperas *dos puntos de salud*.

- **Pez dragon**: Recuperas *toda la salud*

## Enemigos

- **Prisioneros**: Pinguinos controlados por Santa para detenernos. Los sombreros navideños que llevan para controlar sus mentes suelen caerse fácilmente. Es demasiado común verlos en toda la antartida.

    - Vida: 11 puntos
    - Áreas: Todas las áreas con enemigos.

- **Gaviotas**: Atacan a distancia y siempre se alejan al recibir algo de daño, así que deben ser perseguidas para poder derrotarlas.

    - Vida: 36 puntos
    - Áreas: La costa

- **Zorros navideños**: Enviados por Santa para detener a los pinguinos. Suelen resistir los ataques de los pinguinos, pero sus ataques no son tan frecuentes, solo se establecieron en un área porque más afuera les daba más frio.

    - Vida: 50 puntos
    - Áreas: La yanura

- **Morosov**: Jefe de la región. Administra quien sale del ***Polo Sur*** y quien se queda, gracias a un buen trato con Santa el evitara la salida del movimiento Pinguino. La solución, viajar sobre el.

    - Vida: 120 puntos
    - Áreas: Recinto de Morosov