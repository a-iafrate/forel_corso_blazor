# Demo @bind con Formattazione e Conversione

## ?? Panoramica

Questa pagina demo è stata creata per scopi didattici per insegnare agli studenti Blazor come utilizzare la direttiva `@bind` con formattazione e conversione personalizzata.

## ?? Obiettivi di Apprendimento

Gli studenti impareranno:

1. **Binding Base** - Come funziona il two-way data binding in Blazor
2. **Eventi di Binding** - La differenza tra `onchange` e `oninput`
3. **Formattazione Date** - Come formattare DateTime e TimeOnly
4. **Formattazione Numeri** - Come formattare numeri, valute e percentuali
5. **Conversione Personalizzata** - Uso di `@bind:get` e `@bind:set`
6. **@bind:after** - Eseguire codice dopo il binding
7. **Altri Controlli** - Binding con select, checkbox, radio button, range slider

## ?? Struttura della Pagina

### Sezione 1: Binding Base
- Introduzione al concetto di two-way data binding
- Esempio pratico con input text
- Spiegazione del comportamento `onchange` predefinito

### Sezione 2: Eventi di Binding
- Confronto tra `onchange` (default) e `oninput` (real-time)
- Esempi pratici che mostrano quando usare ciascuno
- Caso d'uso: contatore caratteri

### Sezione 3: Formattazione Date
- Binding con `DateTime` per date complete
- Binding con `DateTime` per datetime-local
- Binding con `TimeOnly` per input type="time"
- Tabella di confronto tra valori raw e formattati

### Sezione 4: Formattazione Numeri
- Formattazione di numeri interi con separatore migliaia (N0)
- Formattazione di decimali (N2)
- Formattazione valuta (C2)
- Formattazione percentuale (P2)
- Visualizzazione side-by-side dei risultati

### Sezione 5: Conversione Personalizzata
- Uso di `@bind:get` e `@bind:set` per controllo completo
- Esempio di conversione temperatura (Celsius ? Fahrenheit ? Kelvin)
- Conversione automatica a maiuscolo
- Validazione codice fiscale con feedback visivo

### Sezione 6: @bind:after
- Introduzione all'evento post-binding
- Esempio pratico: calcolatore prezzo con IVA e sconto
- Ricalcolo automatico quando cambia qualsiasi valore

### Sezione 7: Altri Controlli
- Select/dropdown
- Checkbox
- Radio buttons
- Multiple select
- Range slider con visualizzazione real-time

### Sezione 8: Best Practices
- Lista DO (cosa fare)
- Lista DON'T (cosa evitare)
- Tabella di riferimento rapido per tutte le sintassi

## ?? Design e UX

La pagina utilizza:
- **Colori vivaci** per mantenere l'attenzione degli studenti
- **Card colorate** per evidenziare risultati e calcoli
- **Code blocks** per mostrare il codice sorgente
- **Feedback visivo** per validazione (verde/rosso)
- **Animazioni** per rendere l'interfaccia più dinamica

## ?? Tecnologie Utilizzate

- **Blazor WebAssembly** (.NET 9)
- **C# 13.0**
- **Bootstrap 5** per il layout responsive
- **CSS Custom** per styling avanzato
- **TimeOnly** (nuovo in .NET 6+)

## ?? Concetti Chiave

### @bind vs @bind:get/@bind:set

```razor
<!-- Binding semplice -->
<input @bind="nome" />

<!-- Binding con getter/setter personalizzati -->
<input @bind:get="temperatura" @bind:set="SetTemperatura" />
```

### @bind:event

```razor
<!-- Default: onchange (al blur) -->
<input @bind="testo" />

<!-- Real-time: oninput (ad ogni keystroke) -->
<input @bind="testo" @bind:event="oninput" />
```

### @bind:after

```razor
<!-- Esegue metodo dopo il binding -->
<input @bind="prezzo" @bind:after="CalcolaTotale" />
```

### Formattazione

```csharp
// Numeri
numeroIntero.ToString("N0")      // 1,234,567
numeroDecimale.ToString("N2")    // 1,234.56
valuta.ToString("C2")            // €99.99
(percentuale/100).ToString("P2") // 25.50%

// Date
data.ToString("dd/MM/yyyy")                    // 15/12/2024
dataOra.ToString("dd/MM/yyyy HH:mm:ss")       // 15/12/2024 14:30:45
oraSelezionata.ToString("HH:mm")              // 14:30
```

## ?? Come Usare Questa Demo

1. **Per gli Insegnanti:**
   - Segui le sezioni in ordine per una progressione didattica naturale
   - Incoraggia gli studenti a modificare i valori e osservare i risultati
   - Usa gli esempi di codice come base per esercizi pratici

2. **Per gli Studenti:**
   - Leggi attentamente le spiegazioni in ogni sezione
   - Prova a modificare i valori negli input
   - Esamina il codice sorgente per capire come funziona
   - Prova a replicare gli esempi in un tuo progetto

## ?? Risorse Aggiuntive

- [Documentazione Microsoft su Data Binding](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/data-binding)
- [Formattazione Date e Numeri in C#](https://learn.microsoft.com/en-us/dotnet/standard/base-types/formatting-types)
- [Best Practices Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance)

## ?? Esercizi Suggeriti

1. **Base**: Crea un convertitore di unità di misura (metri ? piedi)
2. **Intermedio**: Implementa un calcolatore BMI con validazione
3. **Avanzato**: Crea un form di registrazione completo con validazione personalizzata

## ?? File Correlati

- **Razor Component**: `BlazorForelApp/Pages/BindFormattingDemo.razor`
- **CSS**: `BlazorForelApp/wwwroot/css/bind-formatting-demo.css`
- **Navigation**: Link aggiunto in `BlazorForelApp/Layout/NavMenu.razor`

## ?? Personalizzazioni Possibili

- Aggiungere supporto per culture diverse (IT-it, EN-us, ecc.)
- Implementare validazione più complessa con Fluent Validation
- Aggiungere debouncing per l'evento oninput
- Integrare con EditForm e DataAnnotations
- Aggiungere esempi di binding con oggetti complessi

## ?? Note Importanti

- `TimeOnly` è disponibile solo da .NET 6+
- I formati di valuta dipendono dalla culture corrente
- `@bind:after` è disponibile da .NET 7+
- Le validazioni in questa demo sono semplificate per scopi didattici

## ?? Troubleshooting

**Problema**: Il binding non aggiorna l'UI
- **Soluzione**: Verifica di aver usato `@bind` e non solo `value=`

**Problema**: L'evento oninput causa troppi render
- **Soluzione**: Usa `onchange` o implementa debouncing

**Problema**: La formattazione non funziona come previsto
- **Soluzione**: Verifica la culture dell'applicazione

## ?? Supporto

Per domande o problemi, consulta:
- La documentazione ufficiale di Blazor
- Stack Overflow con tag [blazor]
- Il repository GitHub del corso

---

**Versione**: 1.0  
**Data Creazione**: Dicembre 2024  
**Ultima Modifica**: Dicembre 2024  
**Target Framework**: .NET 9.0  
**Compatibilità**: Blazor WebAssembly / Blazor Server
