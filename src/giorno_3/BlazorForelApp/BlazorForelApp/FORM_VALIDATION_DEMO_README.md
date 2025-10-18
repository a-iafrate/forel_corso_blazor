# Demo Validazione Form con EditForm e DataAnnotations

## ?? Panoramica

Questa pagina demo è stata creata per scopi didattici per insegnare agli studenti Blazor come validare i form usando `EditForm` e `DataAnnotations` in modo professionale e completo.

## ?? Obiettivi di Apprendimento

Gli studenti impareranno:

1. **EditForm Base** - Come usare EditForm con validazione automatica
2. **DataAnnotations** - Tutti gli attributi di validazione comuni
3. **Validazione Custom** - Creare validatori personalizzati per logica di business specifica
4. **Form Complessi** - Validare oggetti annidati e form multi-sezione
5. **Controllo Manuale** - Eventi EditContext e validazione programmatica
6. **Best Practices** - Pattern e anti-pattern nella validazione form

## ?? Struttura della Pagina

### Sezione 1: EditForm Base
Introduce i concetti fondamentali:
- **EditForm** con Model binding
- **DataAnnotationsValidator** per abilitare la validazione
- **ValidationSummary** per mostrare tutti gli errori
- **ValidationMessage** per messaggi specifici per campo
- **OnValidSubmit** vs **OnInvalidSubmit**

**Campi dimostrati:**
- Nome (Required, StringLength)
- Email (EmailAddress)
- Età (Range)

**Concetti chiave:**
```csharp
<EditForm Model="@model" OnValidSubmit="@HandleSubmit">
    <DataAnnotationsValidator />
    <ValidationSummary />
    <InputText @bind-Value="model.Nome" />
    <ValidationMessage For="@(() => model.Nome)" />
</EditForm>
```

### Sezione 2: DataAnnotations Comuni
Una panoramica completa di tutti gli attributi standard:

| Attributo | Scopo | Esempio |
|-----------|-------|---------|
| `[Required]` | Campo obbligatorio | `[Required(ErrorMessage = "...")]` |
| `[StringLength]` | Lunghezza stringa | `[StringLength(50, MinimumLength = 3)]` |
| `[Range]` | Valore numerico in range | `[Range(0, 100)]` |
| `[EmailAddress]` | Formato email | `[EmailAddress]` |
| `[Phone]` | Formato telefono | `[Phone]` |
| `[Url]` | Formato URL | `[Url]` |
| `[RegularExpression]` | Pattern regex | `[RegularExpression(@"^[A-Z]{3}-\d{4}$")]` |
| `[Compare]` | Confronta due campi | `[Compare(nameof(Password))]` |
| `[CreditCard]` | Numero carta credito | `[CreditCard]` |

**Funzionalità:**
- 8 esempi di validazione diversi
- Visualizzazione side-by-side
- Messaggi di errore personalizzati
- Test interattivo di ogni validazione

### Sezione 3: Validazione Personalizzata
Dimostra come creare ValidationAttribute custom per:

1. **Codice Fiscale Italiano**
   - Validazione lunghezza (16 caratteri)
   - Pattern alfanumerico
   - Esempio pratico di validazione custom

2. **Partita IVA**
   - 11 cifre numeriche
   - Validazione formato italiano

3. **Data Nascita (Maggiorenne)**
   - Calcolo età
   - Validazione età minima
   - Confronto con data corrente

4. **IBAN**
   - Formato italiano (IT + 25 caratteri)
   - Validazione prefisso e lunghezza

5. **Password Forte**
   - Minimo 8 caratteri
   - Almeno una maiuscola
   - Almeno una minuscola
   - Almeno un numero
   - Almeno un simbolo

6. **Accettazione Termini**
   - Checkbox obbligatorio
   - Uso di Range per bool

**Esempio di ValidationAttribute custom:**
```csharp
public class CodiceFiscaleAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value, 
        ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success;
        
        var cf = value.ToString()!.ToUpper();
        
        if (cf.Length != 16)
            return new ValidationResult(
                "Il codice fiscale deve essere di 16 caratteri");
        
        if (!Regex.IsMatch(cf, @"^[A-Z0-9]{16}$"))
            return new ValidationResult(
                "Il codice fiscale contiene caratteri non validi");
        
        return ValidationResult.Success;
    }
}
```

### Sezione 4: Form Complesso con Oggetti Annidati
Un esempio realistico di form di registrazione multi-sezione con:

**Dati Personali:**
- Nome, Cognome
- Email, Telefono

**Indirizzo (Oggetto Nested):**
- Via, Civico
- CAP (validato con regex per 5 cifre)
- Città, Provincia (2 lettere)

**Preferenze:**
- Categoria (select dropdown)
- Newsletter (checkbox opzionale)
- Note (textarea con limite caratteri)

**Privacy:**
- Accettazione obbligatoria

**Caratteristiche:**
- Validazione di oggetti nested
- Sezioni visivamente separate
- Form styling professionale
- Submit button con icone

### Sezione 5: Eventi e Controllo Manuale
Dimostra il controllo programmatico della validazione:

**EditContext:**
- Creazione e configurazione
- Eventi OnFieldChanged
- Eventi OnValidationStateChanged
- Stato IsModified

**Funzionalità dimostrate:**
- `editContext.Validate()` - Validazione manuale
- `ValidationMessageStore` - Aggiunta errori custom
- `editContext.NotifyValidationStateChanged()` - Notifica cambio stato
- Log eventi in tempo reale

**Pannello informativo:**
- Stato modificato/non modificato
- Conteggio messaggi di validazione
- Lista errori correnti
- Log eventi temporizzato

**Esempio:**
```csharp
private EditContext editContext;

protected override void OnInitialized()
{
    editContext = new EditContext(model);
    editContext.OnFieldChanged += HandleFieldChanged;
    editContext.OnValidationStateChanged += HandleValidationStateChanged;
}

private void ValidateManually()
{
    var isValid = editContext.Validate();
    // Gestisci risultato
}

private void AddCustomError()
{
    var messages = new ValidationMessageStore(editContext);
    messages.Add(
        editContext.Field(nameof(model.Email)), 
        "Errore personalizzato"
    );
    editContext.NotifyValidationStateChanged();
}
```

### Sezione 6: Best Practices
Guida completa su cosa fare e cosa evitare:

**DO (Cosa Fare) ?**
- Usa DataAnnotationsValidator per validazione automatica
- Mostra ValidationMessage vicino ad ogni campo
- Usa OnValidSubmit per gestire solo form validi
- Fornisci messaggi di errore chiari e specifici
- Valida sia client-side che server-side
- Usa attributi custom per logica di business complessa
- Disabilita il pulsante submit durante l'invio

**DON'T (Cosa Evitare) ?**
- Non fare validazione solo client-side (sicurezza!)
- Non mostrare troppi errori contemporaneamente
- Non usare messaggi di errore generici
- Non dimenticare di validare oggetti nested
- Non fare validazioni complesse in getters/setters
- Non ignorare ValidationSummary per panoramica errori
- Non permettere submit multipli senza controllo

**Tabella di Riferimento Rapido:**
Tabella completa di tutti gli attributi DataAnnotations con descrizione ed esempi.

## ?? Design e UX

### Styling Professionale
- **Form sections** con bordi colorati
- **Validation feedback** visivo (rosso per errori)
- **Success messages** con animazioni
- **Code examples** con syntax highlighting
- **Responsive design** per mobile

### Visual Feedback
- Bordi rossi per campi non validi
- Check verde per campi validi
- Animazioni per messaggi di errore
- Badge colorati per stati
- Log in tempo reale con timestamp

### Colori e Temi
- Azzurro (#3498db) per elementi informativi
- Verde (#27ae60) per successo
- Rosso (#e74c3c) per errori
- Viola gradiente per bottoni primari
- Verde gradiente per registrazione

## ?? Componenti Blazor Utilizzati

### Input Components
- `InputText` - Text input
- `InputNumber` - Numeric input
- `InputDate` - Date picker
- `InputSelect` - Dropdown select
- `InputCheckbox` - Checkbox
- `InputTextArea` - Multi-line text

### Validation Components
- `EditForm` - Form container con validazione
- `DataAnnotationsValidator` - Validatore automatico
- `ValidationSummary` - Riepilogo errori
- `ValidationMessage` - Messaggio per campo

### Eventi EditForm
- `OnValidSubmit` - Submit con form valido
- `OnInvalidSubmit` - Submit con form non valido
- `OnSubmit` - Submit generico (gestione manuale)

## ?? Tecnologie e Pattern

### Tecnologie
- **Blazor WebAssembly** (.NET 9)
- **C# 13.0**
- **System.ComponentModel.DataAnnotations**
- **EditContext** per controllo avanzato

### Pattern Implementati
- **Model-View pattern** con classi POCO
- **Validation attributes** per regole dichiarative
- **Custom validators** per logica complessa
- **Event-driven validation** con EditContext
- **Nested object validation** per modelli complessi

## ?? Modelli di Dati

### BasicFormModel
Modello semplice per introduzione:
```csharp
public class BasicFormModel
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Nome { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [Range(18, 120)]
    public int Eta { get; set; }
}
```

### RegistrationFormModel
Modello complesso con oggetti nested:
```csharp
public class RegistrationFormModel
{
    [Required]
    public string Nome { get; set; }
    
    [Required]
    public IndirizzoModel Indirizzo { get; set; }
    
    [Range(typeof(bool), "true", "true")]
    public bool AccettaPrivacy { get; set; }
}

public class IndirizzoModel
{
    [Required]
    public string Via { get; set; }
    
    [RegularExpression(@"^\d{5}$")]
    public string Cap { get; set; }
}
```

## ?? Come Usare Questa Demo

### Per gli Insegnanti
1. **Sequenza didattica**: Segui le sezioni in ordine crescente di complessità
2. **Live coding**: Mostra come creare validatori custom partendo dagli esempi
3. **Esercizi pratici**: Fai modificare gli studenti aggiungendo nuovi campi
4. **Debugging**: Usa la sezione 5 per mostrare come debuggare la validazione

### Per gli Studenti
1. **Studia ogni sezione** comprendendo i concetti base
2. **Sperimenta** modificando i valori e osservando la validazione
3. **Leggi il codice** negli esempi per capire l'implementazione
4. **Replica** gli esempi in un tuo progetto personale
5. **Estendi** creando nuovi validatori per le tue esigenze

## ?? Esercizi Suggeriti

### Livello Base ??
1. Crea un form di login con email e password
2. Aggiungi validazione lunghezza minima password
3. Implementa un campo "ricordami" (checkbox)

### Livello Intermedio ??
1. Crea un form multi-step con validazione per ogni step
2. Implementa un validatore per codice postale
3. Aggiungi validazione dipendente (campo A richiesto solo se B è valorizzato)

### Livello Avanzato ??
1. Crea un validatore asincrono che verifica username su API
2. Implementa validazione cross-field complessa (es. data inizio < data fine)
3. Crea un sistema di validazione con regole configurabili da JSON

## ?? Dettagli Tecnici

### Validazione Client vs Server
- **Client-side**: Immediata, UX migliore, non sicura
- **Server-side**: Sicura, definitiva, più lenta
- **Best practice**: Entrambe! Client per UX, server per sicurezza

### Performance
- DataAnnotations è efficiente per la maggior parte dei casi
- Per validazioni complesse, considera FluentValidation
- Evita validazioni sincrone che chiamano API

### Accessibilità
- ValidationMessage associati ai campi per screen reader
- Aria labels su input required
- Focus automatico su primo errore (personalizzabile)

## ?? File del Progetto

- **Component**: `BlazorForelApp/Pages/FormValidationDemo.razor`
- **Styling**: `BlazorForelApp/wwwroot/css/form-validation-demo.css`
- **Navigation**: Link in `BlazorForelApp/Layout/NavMenu.razor`

## ?? Risorse Aggiuntive

### Documentazione Microsoft
- [Data Annotations in Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms-validation)
- [Built-in Validation Attributes](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation)
- [EditForm Component](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms-validation)

### Librerie Esterne
- **FluentValidation.Blazor** - Validazione con fluent API
- **Blazored.FluentValidation** - Integrazione FluentValidation
- **MudBlazor** - Componenti UI con validazione integrata

### Pattern Avanzati
- Validazione condizionale
- Validazione asincrona
- Validazione cross-field
- Validazione localizzata

## ?? Note Importanti

### Sicurezza
?? **MAI** fare validazione solo client-side per dati sensibili o critici!
- Client-side può essere bypassato
- Server-side è sempre obbligatorio
- Client-side migliora solo l'UX

### Culture e Localizzazione
- I messaggi di errore possono essere localizzati
- Usa resources per messaggi multilingua
- Considera culture per date e numeri

### Compatibilità Browser
- EditForm funziona su tutti i browser moderni
- Alcuni attributi HTML5 (email, tel) hanno supporto variabile
- Testa sempre su browser target

## ?? Troubleshooting Comuni

### Validazione non funziona
? **Soluzione**: Verifica di aver aggiunto `<DataAnnotationsValidator />`

### Messaggi non appaiono
? **Soluzione**: Controlla namespace e `<ValidationMessage For="..." />`

### Form si submit anche se non valido
? **Soluzione**: Usa `OnValidSubmit` invece di `OnSubmit`

### Validazione oggetti nested non funziona
? **Soluzione**: In .NET 6+ la validazione nested è automatica, in versioni precedenti serve validazione custom

### Messaggi in inglese
? **Soluzione**: Usa `ErrorMessage` nell'attributo o configura localizzazione

## ?? Aggiornamenti Futuri

Possibili estensioni della demo:
- [ ] Validazione asincrona con API call
- [ ] Integrazione con FluentValidation
- [ ] Form wizard multi-step
- [ ] Upload file con validazione
- [ ] Validazione dinamica basata su regole
- [ ] Export/Import modelli con validazione
- [ ] Test unitari per validatori custom

## ?? Supporto

Per domande, problemi o suggerimenti:
- Consulta la documentazione Microsoft
- Chiedi su Stack Overflow con tag [blazor] e [validation]
- Apri una issue nel repository del corso

---

**Versione**: 1.0  
**Data Creazione**: Dicembre 2024  
**Target Framework**: .NET 9.0  
**Compatibilità**: Blazor WebAssembly / Blazor Server  
**Livello**: Intermedio-Avanzato  
**Tempo Stimato Studio**: 2-3 ore
