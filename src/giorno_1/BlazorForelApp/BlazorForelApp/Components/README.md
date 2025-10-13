# Esempi di Componenti Personalizzati Blazor

Questa sezione del corso dimostra come creare e utilizzare componenti personalizzati in Blazor.

## Componenti Creati

### 1. PersonCard (`Components/PersonCard.razor`)

Un componente che mostra informazioni di una persona in formato card. Dimostra:

- **Parametri**: Come ricevere dati dal componente parent
- **Eventi**: Come comunicare dal figlio al parent
- **Stato interno**: Come mantenere stato privato nel componente
- **Conditional rendering**: Come mostrare contenuto condizionale

**Parametri principali:**
- `Name`: Nome della persona
- `Age`: Età 
- `Email`: Email
- `Role`: Ruolo lavorativo
- `Description`: Descrizione opzionale
- `ShowClickCount`: Se mostrare il contatore di clic

**Eventi:**
- `OnContact`: Scatenato quando si clicca "Contatta"
- `OnViewProfile`: Scatenato quando si clicca "Profilo"

### 2. CustomCounter (`Components/CustomCounter.razor`)

Un contatore personalizzabile che dimostra:

- **Configurabilità**: Parametri per min/max/step
- **Stili CSS integrati**: CSS scoped nel componente
- **Logica di business**: Validazione e calcoli interni
- **Binding bidirezionale**: Comunicazione con il parent

**Parametri principali:**
- `Label`: Etichetta del contatore
- `InitialValue`: Valore iniziale
- `MinValue`/`MaxValue`: Range dei valori
- `Step`: Incremento per ogni operazione
- `ShowStep`: Se mostrare l'informazione dello step

**Eventi:**
- `OnValueChanged`: Scatenato ogni volta che il valore cambia

## Pagina di Esempio (`Pages/ComponentsExample.razor`)

La pagina dimostra:

1. **Utilizzo multiplo**: Come usare lo stesso componente con configurazioni diverse
2. **Gestione eventi**: Come intercettare e gestire eventi dai componenti figli
3. **Log di sistema**: Come tracciare le interazioni per debugging/monitoraggio
4. **Bootstrap integration**: Come integrare componenti custom con Bootstrap

## Concetti Didattici Coperti

### Parametri `[Parameter]`
```csharp
[Parameter] public string Name { get; set; } = "Default";
```

### Eventi `[EventCallback]`
```csharp
[Parameter] public EventCallback<string> OnContact { get; set; }
```

### Ciclo di vita del componente
```csharp
protected override void OnInitialized()
{
    // Inizializzazione
}
```

### CSS Scoped
```html
<style>
    .my-class { /* stili locali al componente */ }
</style>
```

### Rendering condizionale
```html
@if (condition)
{
    <div>Contenuto condizionale</div>
}
```

## Come Usare

1. Navigare alla pagina "Componenti" nel menu
2. Interagire con i diversi esempi
3. Osservare il log delle azioni in fondo alla pagina
4. Esaminare il codice sorgente dei componenti

Questo esempio fornisce una base solida per comprendere come strutturare e utilizzare componenti personalizzati in Blazor.