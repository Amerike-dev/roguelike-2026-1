# Sistema de movimiento Player


### Movimiento teclado y control

El ***sistema viejo de inputs*** dentro de Unity contiene los Input Axis. Estos Axis estan predefinidos con input de botones ya definidos para facilitar el registro del jugador.

El input **"Horizontal"** y **"Vertical"** sirven para leer las teclas "WASD" o las flechas del teclado, pero de igual manera se pueden leer las entradas del control. Además de contar con otro apartado llamado **"Fire"** y **"Jump"**.

**"Fire"** esta configurado inicialmente para responder a los clicks de ***Mouse 0, 1 y 2***; **"Jump"** esta configurado para responder al recibir el input de la tecla ***"Espacio"***. Más también pueden recibir la lectura de Joystick button:

Fire: **joystick button 0** *(Xbox: A, PlayStation: Cuadrado)*, **joystick button 1** *(Xbox: B, PlayStation: X)*, **joystick button 2** *(Xbox: X, PlayStation: Circulo)*.

Jump: **joystick button 3** *(Xbox: Y, PlayStation: Triangulo)*.

---

### Estados de velocidad

La escala de velocidad del jugador se mide en valores de **1 - 15**, donde **1** es *muy lento* y **15** es *muy rápido*.

Hay que tomar en consideración que muy lento no significa que el personaje aparente no moverse y muy rápido signifique que atraviesa el mapa en cuestion de *segundos*. Sino que en su velocidad más baja recorra menos que medio *tile* y en la más alta pueda mantener una velocidad constante, incrementada en un valor de x1.15.

La velocidad ***estandar*** es de **5 a 6** en esta escala antes propuesta.

#### Que puede bajar la velocidad del jugador:

- Ya no disponer del atributo "*humedad*" que, además de servir como contador para el costo y uso de habilidades especiales, también ayuda a medir la capacidad de movimiento con la que cuenta el pinguino. Este efecto se pierde al ir recuperando humedad.
    
    - El valor dentro de la escala baja gradualmente hasta llegar al **1**

- El estado de "*intoxicación*" se puede dar con distintos consumibles que no logran hacer digestion en el pinguino. Ejemplo de esto pueden ser productos humanos: frituras o capsulas de medicina. El estado de intoxicación se pierde al consumir algun *consumible natural* o al pasar de fase.

    - El valor dentro de la escala se reducen de **3 a 2** unidades.

- Ser *aturdido* por ataques de alto impacto de los enemigos se modifica la velocidad y se invierten la entrada de **inputs** por unos segundos.

    - El valor dentro de la escala se reduce únicamente una unidad. Ej. El valor estandar de velocidad es **5**, por lo tanto se ve reducido a **4**.

- Las ***armas*** y ***habilidades del jefe*** pueden modificar estos valores por igual.

    - El valor se encuentra especificado dentro de las armas y habilidades.

#### Que puede aumentar la velocidad del jugador:

- En escenarios gelidos la velocidad del jugador va aumentando conforme se este deslizando en el hielo. Andar por estas casillas también significa que el jugador *no tiene el control total* de la dirección y fricción del pinguino mientras este sobre aquellas casillas.

    - El valor dentro de la escala aumenta de **2** a un máximo de **4** unidades temporalmente.

- En escenarios donde se encuentren cuerpos de agua el jugador a puede trasladarse por esta aumentando su velocidad, **pero** perdiendo la capacidad de atacar a los enemigos mientras esten dentro de esas casilas.

    - El valor dentro de la escala aumenta un total de **3** unidades.

- Hay consumibles que pueden ayudar a mejorar la velocidad del jugador. Ej:

    - Salmon
    - Sardinas
    - Frutas regionales
    - Insectos
    
    El valor dentro de la escala aumenta un total de **1** a **4** unidades de manera permanente o durante la fase actual.

- Las ***armas*** y ***habilidades del jefe*** pueden modificar estos valores por igual.

    - El valor se encuentra especificado dentro de las armas y habilidades.

---

### Sistema de Inputs

El uso del ***viejo sistema de inputs** es un sistema que todos los miembros del equipo han utilizado evitando retrardos en la elaboración del proyecto.