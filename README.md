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
Aunque visualmente respeta la estética del juego original, el motor interno fue diseñado aplicando patrones de ingeniería de software para garantizar escalabilidad:

* **GridManager Lógico:** El tablero no depende de colisiones visuales para la construcción. Utiliza una matriz matemática bidimensional en memoria para gestionar el estado del terreno (Ocupado/Vacío) con validación en tiempo real.
* **Motor Relacional de Fusiones:** El sistema de combinaciones de plantas funciona a través de un diccionario de *Tuplas* en C#, actuando como una base de datos ultrarrápida que destruye, instancia y actualiza el ID lógico en un solo micro-ciclo de procesamiento.
* **Separación de Capas (Backend/Frontend):** Las entidades lógicas (salud, daño, estados) están completamente aisladas de los *sprites* visuales, permitiendo aplicar el comportamiento de fusión a cualquier objeto con solo cambiar su identificador numérico.
* **Físicas y Hitboxes Desacoplados:** El sistema de daño utiliza componentes `Collider2D` delegados, conectando las colisiones del motor de físicas directamente a las variables de salud de los scripts principales de manera limpia.
* **Patrón Singleton y UI Desacoplada:** La economía se gestiona a través de una instancia global única (`GestorEconomia`), la cual actualiza la interfaz de usuario en tiempo real sin crear dependencias circulares.
* **Sistema de Enfriamiento (Cooldowns):** Gestión asíncrona mediante Corrutinas acopladas al `UIManager` que controlan el bloqueo lógico de selección y el feedback visual (`Image.fillAmount`) de las tarjetas de semillas de forma independiente.
* **Polimorfismo en Entidades:** Las plantas defensivas y productoras heredan de una clase base común, permitiendo a la IA de los enemigos interactuar genéricamente con cualquier obstáculo.
* **Director de Oleadas (Corrutinas):** El flujo de enemigos está aislado en un sistema asíncrono que programa instancias matemáticas en los carriles basándose en listas de reproducción y tiempos de preparación.

---

## 🚀 Estado Actual del Desarrollo
- [x] Generación procedural de la matriz del jardín.
- [x] Traducción de inputs (píxeles a coordenadas del tablero).
- [x] Sistema binario de plantación e instanciación de Prefabs.
- [x] Diccionario relacional para fusiones exitosas.
- [x] Comportamiento autónomo de combate (Temporizadores e instanciación de proyectiles).
- [x] Máquina de estados para enemigos (Caminar / Masticar / Morir).
- [x] Sistema económico de generación y recolección de Soles.
- [x] Spawner automatizado por oleadas.
- [x] Tiempos de recarga (Cooldowns) y feedback visual en UI.

---

## 🛠️ Tecnologías Utilizadas
* **Motor:** Unity Editor (2022.3 LTS+)
* **Lenguaje:** C# (.NET)
* **Control de Versiones:** Git / GitHub LFS
