# VuforiaTierpark
# Nutzung
Sofort beim Start der Applikation wird die Kamera gestartet. Nun können die entsprechenden Targets eingescannt werden.

## Das Hauptmenü
Drückt man auf den Button **oben, rechts** öffnet sich das Hauptmenü
* **Spiel Starten:** Die Schnitzeljagd wird gestartet und der erste Hinweis wird angezeigt.
* **Zurück:** Schließt das Hauptmenü.
* **Beenden:** Beendet die Applikation

## Die Besucher Karte
Mit der ausgeklappten Karte lassen sich die einzelnen Gehege genauer betrachten. Hier genügt es auf das Gehege zu klicken oder es mit dem Finger zu berühren.
Nun werden Informationen zu dem Gehege und seinen Bewohnern gezeigt.
Sind in einem Gehege mehr als eine Tierart vertreten kann über die Buttons an der Seite gewechselt werden.
Das Event Menu zeigt alle Events an sowie deren Startzeitpunkt und Entfernung.

<details><summary>image</summary><img src="https://user-images.githubusercontent.com/63050357/105511121-d9620f00-5ccf-11eb-9848-c22a4fd0ff88.jpg" width="800"/></details>

Das Tipp-Menü wird verwendet sobald das Spiel gestartet wird.
Drückt man auf "Nächster Hinweis" wird ein weiterer Hinweis angezeigt.
Faltet man die Karte zusammen sieht man nur die Hinweise und kann zwischen ihnen wechseln.

<details><summary>image</summary><img src="https://user-images.githubusercontent.com/63050357/105511706-7de45100-5cd0-11eb-9b35-8728981e2350.jpg" width="800"/></details>

## Die Tier Targets
Diese Targets dienen nicht der Interaktion.
Scannt man sie bei laufendem Spiel ein wird überprüft ob das richtige Tier gefunden wurde. Wenn ja wird ein neues Tier ausgewählt.
Findet man drei Tier ist das Spiel gewonnen. Danach lässt sich das Spiel neu starten oder man kehrt zur Karte zurück.

<details><summary>image</summary><img src="https://user-images.githubusercontent.com/63050357/105511918-c13ebf80-5cd0-11eb-8f03-9fc0e84ecfa8.jpg" width="800"/></details>

## Die Datenbank
Um die Daten zu persistieren wird eine SQLite Datenbank verwendet. Die einzelnen Tabellen werden über die entsprechenden DAO-Scripte angesprochen. Die Datenbank befindet sich auf dem  **Application.persistentDataPath**.
