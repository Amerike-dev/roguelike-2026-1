Esta carpeta debe contener todos los archivos de codigo Clases. Va a estar separado en diferentes subcarpetas. Es vital mantenerla organizada.

- Core/: El centro del sistema, clases que no dependen de la logica especifica. Clases que no heredan de monobehavior.

- Systems/: Managers principales, como `GameManager`, `EventManager`, `SaveSystem`, que funcionan de forma global.

- GamePlay/: Componentes que van adujntos a GameObjects, deben ser siempre controllers que hereden de monobehavior.