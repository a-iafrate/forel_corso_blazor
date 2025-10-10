# ?? Demo Blazor.Bootstrap - Guida per il Corso

## Panoramica
Questa pagina dimostra i principali componenti della libreria **Blazor.Bootstrap**, una potente implementazione di Bootstrap 5 per Blazor che fornisce componenti UI pronti all'uso.

## Componenti Dimostrati

### ?? Alert Components
- **Alert primario**: Con icona e possibilità di chiusura
- **Alert di successo**: Per notificare operazioni completate
- **Alert di avviso**: Per messaggi importanti

### ?? Button Components
- **Varietà di colori**: Primary, Secondary, Success, Danger
- **Stili diversi**: Outline, dimensioni varie
- **Button con loading**: Mostra stato di caricamento durante operazioni asincrone
- **Interattività**: Contatore di click per dimostrare l'integrazione con C#

### ??? Badge Components
- **Badge colorati**: Tutti i colori di Bootstrap
- **Badge annidati**: Esempio di badge con contatori
- **Uso pratico**: Perfetti per notifiche e stato

### ?? Progress Components
- **Barra di progresso base**: Con valore dinamico
- **Barra striata**: Con pattern visivo
- **Barra animata**: Con animazione continua
- **Aggiornamento dinamico**: Bottone per cambiare il valore

### ?? Modal Component
- **Modal reattivo**: Si adatta a diverse dimensioni schermo
- **Footer personalizzabile**: Con bottoni per azioni
- **Integrazione Blazor**: Gestione tramite riferimenti e metodi async

### ?? Accordion Component
- **Sezioni collassabili**: Per organizzare contenuti lunghi
- **Icone personalizzate**: Per migliorare l'esperienza utente
- **Perfetto per FAQ**: O documentazione strutturata

### ?? Tabs Component
- **Navigazione tra sezioni**: Contenuto organizzato in tab
- **Contenuto dinamico**: Ogni tab può contenere qualsiasi componente Blazor
- **Responsive**: Si adatta automaticamente alle dimensioni

### ?? Toast Component
- **Notifiche non invasive**: Messaggi che scompaiono automaticamente
- **Tipi diversi**: Success, Error, Info
- **Servizio iniettato**: Facile integrazione nel codice

### ? Spinner Component
- **Indicatori di caricamento**: Per operazioni in corso
- **Stili diversi**: Spinning e Growing
- **Dimensioni varie**: Small, Normal, Large
- **Colori Bootstrap**: Consistenti con il design system

### ?? Statistiche Interazioni
Una sezione speciale che dimostra come i componenti Blazor.Bootstrap si integrano perfettamente con la logica C#, mostrando contatori in tempo reale delle interazioni dell'utente.

## Caratteristiche Tecniche

### Installazione
```bash
dotnet add package Blazor.Bootstrap
```

### Configurazione nel Program.cs
```csharp
builder.Services.AddBlazorBootstrap();
```

### Import negli _Imports.razor
```csharp
@using BlazorBootstrap
```

### Riferimenti CSS/JS nell'index.html
- Bootstrap Icons per le icone
- CSS di Blazor.Bootstrap
- JavaScript di Bootstrap e Blazor.Bootstrap

## Vantaggi di Blazor.Bootstrap

1. **Componenti TypeSafe**: Tutti i parametri sono fortemente tipizzati
2. **Integrazione Perfetta**: Nessun JavaScript personalizzato necessario
3. **Responsive by Design**: Tutti i componenti seguono le best practices di Bootstrap
4. **Accessibilità**: Supporto ARIA e standard di accessibilità
5. **Personalizzazione**: Facile customizzazione tramite CSS e parametri
6. **Performance**: Ottimizzato per Blazor WebAssembly e Server

## Esempi di Codice

### Button con Loading
```razor
<Button Color="ButtonColor.Primary" Loading="@isLoading" @onclick="OnLoadingButtonClick">
    @if (isLoading)
    {
        <span>Caricamento...</span>
    }
    else
    {
        <span>Clicca per Loading</span>
    }
</Button>
```

### Toast Service
```csharp
ToastService.Notify(new ToastMessage(
    ToastType.Success, 
    "Successo!", 
    "Operazione completata con successo! ??"
));
```

### Modal con riferimento
```razor
<Modal @ref="modal" Title="Demo Modal">
    <BodyTemplate>
        <p>Contenuto del modal</p>
    </BodyTemplate>
</Modal>

@code {
    private Modal modal = default!;
    
    private async Task ShowModal()
    {
        await modal.ShowAsync();
    }
}
```

## Utilizzo nel Corso

Questa demo è progettata per mostrare agli studenti:
1. Come integrare librerie di componenti esterne
2. L'importanza del design system Bootstrap
3. Gestione dello stato in Blazor
4. Interazione tra componenti UI e logica C#
5. Best practices per UX/UI in applicazioni web moderne

## Risorse Aggiuntive

- [Documentazione Blazor.Bootstrap](https://blazorbootstrap.com/)
- [Bootstrap 5 Documentation](https://getbootstrap.com/docs/5.3/)
- [Blazor Documentation](https://docs.microsoft.com/en-us/aspnet/core/blazor/)

---

**Note per il Docente**: Questa demo è interattiva - invita gli studenti a cliccare sui vari componenti per vedere come cambiano le statistiche in tempo reale!