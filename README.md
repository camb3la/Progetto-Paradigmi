# Libreria Paradigmi Avanzati di Programmazione

## Obbiettivo 
Realizzare una web api che permetta la gestione di un catalogo di una libreria.

## Funzionalità
### Utenti
- Creazione di un utente (anonima senza autenticazione)
- Autenticazione

### Categorie
- Creazione di una categoria (non possono esistere due categorie con lo stesso nome)
- Eliminazione di una categoria (solamente se la categoria non contiene libri)

### Libri
- Caricamento di un libro
- Modifica di un libro
- Eliminazione di un libro
- Ricerca di un libro in base alle seguenti proprietà (obbligatoria almeno un filtro):
  - Categoria
  - Nome del libro
  - Data di Pubblicazione
  - Autore
- La ricerca dovrà paginare i risultati, in base ad un parametro passato nella chiamata

## Istruzioni per l'utilizzo
1. Scaricare la cartella del progetto dal link github e aprirlo su Visual Studio
2. Creare un Server sul proprio Pc rispettando i parametri che si trovano all'interno della stringa di connessione al DB nel file Paradigmi.Models/Context/MyDbContext.cs o modificarlo in base alle proprie esigenze
3. Una volta creato il DB, creare le tabelle tramite una query copia e incollando il contenuto del file /Paradigmi.Enterprise.Models/Database/dump.sql
4. Avviare il progetto da Visual Studio
5. Creare un utente e poi effettuare il login tramite Crea Token.
6. Utilizzare il token JWT restituito per autenticarsi
