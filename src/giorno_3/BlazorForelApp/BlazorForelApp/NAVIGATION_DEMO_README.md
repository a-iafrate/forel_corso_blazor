# Demo Navigazione Blazor

Questa demo mostra le varie tecniche di navigazione disponibili in Blazor WebAssembly.

## Pagine Create

### 1. NavigationDemo.razor (`/navigation-demo`)
Pagina principale che presenta tutte le funzionalità di navigazione disponibili:

- **Navigazione con NavLink**: Link dichiarativi nel markup
- **Navigazione Programmatica**: Utilizzo di NavigationManager in C#
- **Parametri di Route**: Passaggio di parametri attraverso l'URL
- **Query String**: Parametri come query string
- **Parametri Opzionali**: Route con parametri opzionali
- **Oggetti Complessi**: Passaggio di dati strutturati

### 2. DemoPageSimple.razor (`/demo-page-simple`)
Dimostra la navigazione di base con NavLink.

### 3. DemoPageWithParam.razor (`/demo-page-with-param/{id:int}`)
Mostra come utilizzare parametri di route tipizzati con constraint.

**Esempi di URL:**
- `/demo-page-with-param/123`
- `/demo-page-with-param/456`

### 4. DemoPageQuery.razor (`/demo-page-query`)
Dimostra l'utilizzo di parametri query string con l'attributo `[SupplyParameterFromQuery]`.

**Esempi di URL:**
- `/demo-page-query?name=Mario&age=30`
- `/demo-page-query?name=Luca&age=25`

### 5. DemoPageOptional.razor
Route multiple per parametri opzionali:
- `/demo-page-optional` (senza parametri)
- `/demo-page-optional/{category?}` (con parametro opzionale)

**Esempi di URL:**
- `/demo-page-optional`
- `/demo-page-optional/tecnologia`
- `/demo-page-optional/sport`
- `/demo-page-optional/casa`

### 6. DemoPageState.razor (`/demo-page-state`)
Dimostra il passaggio di oggetti complessi attraverso query string.

**Esempio di URL:**
`/demo-page-state?name=Smartphone&price=699.99&id=1`

## Concetti Dimostrati

### NavLink vs NavigationManager
- **NavLink**: Componente dichiarativo per link, ideale per menu e navigazione statica
- **NavigationManager**: Servizio per navigazione programmatica, utile per navigazione condizionale

### Tipi di Parametri
1. **Route Parameters**: `{id:int}` - Parametri nella route con constraint di tipo
2. **Query Parameters**: `?name=value&age=30` - Parametri dopo il `?` nell'URL
3. **Optional Parameters**: `{category?}` - Parametri opzionali che possono essere omessi

### Constraint di Route
- `int`: Solo numeri interi
- `decimal`: Numeri decimali
- `bool`: Valori boolean
- `datetime`: Date e orari
- `guid`: GUID

### Attributi Blazor
- `[Parameter]`: Per parametri di route
- `[SupplyParameterFromQuery]`: Per parametri da query string

## Come Usare la Demo

1. Avvia l'applicazione Blazor
2. Naviga a `/navigation-demo`
3. Esplora le varie sezioni della demo
4. Testa i diversi tipi di navigazione
5. Osserva come cambiano gli URL e come vengono passati i parametri

## Utilizzo nel Corso

Questa demo è perfetta per:
- Spiegare i concetti di routing in Blazor
- Mostrare le differenze tra i vari approcci
- Permettere agli studenti di sperimentare
- Fornire esempi pratici di codice
- Dimostrare best practices

## Codice di Esempio

```csharp
// Navigazione programmatica
@inject NavigationManager Navigation

private void NavigateToProduct(int productId)
{
    Navigation.NavigateTo($"/products/{productId}");
}

// Parametri di route
[Parameter] public int Id { get; set; }

// Query string
[SupplyParameterFromQuery(Name = "search")] 
public string? SearchTerm { get; set; }
```

## Note per il Corso

- Inizia con la navigazione semplice (NavLink)
- Prosegui con la navigazione programmatica
- Spiega i constraint di route
- Mostra l'utilizzo delle query string
- Conclude con esempi di oggetti complessi
- Fai sperimentare gli studenti con gli esempi interattivi