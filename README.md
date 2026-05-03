# 🌻 PvZ Fusion Engine (C# / Unity)
![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)

Un motor de juego 2D de código abierto construido desde cero en **Unity** y **C#**, inspirado en las mecánicas del clásico *Plants vs. Zombies*, pero introduciendo un sistema de **fusión de entidades en tiempo real**.

Este proyecto es estrictamente un **Fan-Game técnico y educativo sin fines de lucro**.

---

## ⚠️ Disclaimer Legal
*Este proyecto es un tributo creado por un fan con fines de aprendizaje en arquitectura de software y desarrollo de videojuegos. Todos los derechos de propiedad intelectual, arte, personajes y audio originales de "Plants vs. Zombies" pertenecen a **Electronic Arts (EA)** y **PopCap Games**. Este proyecto no genera ningún tipo de ingreso y no está afiliado a sus creadores originales.*

---

## ⚙️ Arquitectura Técnica
El motor ha sido diseñado aplicando patrones de ingeniería para garantizar escalabilidad y un desacoplamiento efectivo entre lógica y representación visual:

* **GridManager Lógico:** El tablero utiliza una matriz matemática bidimensional que gestiona el estado del terreno (Ocupado/Vacío) con validación en tiempo real[cite: 4]. El sistema calcula automáticamente las posiciones de instancia basándose en el ancho (`1.2f`) y alto (`1.5f`) de celda definido[cite: 4].
* **Motor Relacional de Fusiones:** Las combinaciones de plantas operan a través de un diccionario de `Tuplas` en C#, permitiendo identificar recetas de fusión, destruir las entidades base y actualizar el ID lógico del tablero en un solo ciclo de procesamiento[cite: 4].
* **Defensa de Última Línea (Cortadoras):** Sistema de limpieza de carriles que utiliza detección de colisiones mediante `HitboxEnemigo`[cite: 5]. Al activarse, inicia un motor cinemático que aplica daño masivo y se desplaza horizontalmente hasta el límite de la escena[cite: 4, 5].
* **Feedback Visual de Daño:** Sistema de corrutinas desacoplado que manipula la propiedad `color` del `SpriteRenderer` para generar un efecto de "Flash White" instantáneo al recibir impacto, optimizando el *game feel* sin redundancia de materiales[cite: 5].
* **Gestión de Economía y Soles:** La economía se centraliza en un `GestorEconomia` (Singleton) que procesa la recolección de soles[cite: 2]. Los soles utilizan parábolas físicas para su aparición y traslación lineal hacia la UI mediante la conversión de coordenadas de mundo a pantalla[cite: 3, 8].
* **Director de Oleadas:** El flujo de enemigos es gestionado por un sistema asíncrono (`SpawnerOleadas`) que programa instancias basadas en configuraciones de oleada y tiempos de preparación[cite: 9].
* **Físicas y Hitboxes Desacoplados:** El sistema de daño utiliza componentes `Collider2D` delegados que conectan las colisiones físicas con las variables de salud de los scripts principales de manera limpia[cite: 5, 7].

---

## 🚀 Estado Actual del Desarrollo
- [x] Generación procedural de la matriz del jardín[cite: 4].
- [x] Traducción de inputs (píxeles a coordenadas del tablero)[cite: 4].
- [x] Diccionario relacional para fusiones exitosas[cite: 4].
- [x] Sistema económico de generación y recolección de Soles[cite: 2, 8].
- [x] **Feedback visual (Flash) al recibir daño en enemigos**[cite: 5].
- [x] **Sistema de Cortadoras de Césped funcional por carril**.
- [x] Spawner automatizado por oleadas[cite: 9].
- [x] Tiempos de recarga (Cooldowns) y feedback visual en UI.
- [ ] Integración de arte final y animaciones cuadro por cuadro (En proceso).

---

## 🛠️ Tecnologías Utilizadas
* **Motor:** Unity Editor (6000.0.44f1)[cite: 1]
* **Lenguaje:** C# (.NET)
* **Control de Versiones:** Git / GitHub
