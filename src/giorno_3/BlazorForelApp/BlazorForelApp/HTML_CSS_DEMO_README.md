# Demo HTML e CSS per Blazor

Questa pagina dimostra le tecniche avanzate di personalizzazione di componenti Blazor utilizzando HTML e CSS moderni.

## Caratteristiche Implementate

### 1. **Pulsanti Personalizzati**
- **Pulsante Gradiente**: Usa `linear-gradient` con effetti di hover e animazioni
- **Pulsante Neon**: Effetto luminoso con animazioni e trasparenze
- **Pulsante 3D**: Effetto tridimensionale con ombre multiple
- **Pulsante Loading**: Spinner CSS integrato con stati di caricamento

### 2. **Card Avanzate**
- **Card Hover Effect**: Animazioni al passaggio del mouse con `transform` e `box-shadow`
- **Card Glassmorphism**: Effetto vetro moderno con `backdrop-filter` e trasparenze

### 3. **Controlli Form Personalizzati**
- **Input con Label Floating**: Etichette animate che si spostano durante il focus
- **Toggle Switch**: Interruttore personalizzato con animazioni fluide
- **Range Slider**: Slider customizzato con stile personalizzato
- **Underline Animation**: Sottolineatura animata per gli input

### 4. **Layout Moderni**
- **CSS Grid**: Layout responsivo con aree denominate
- **Flexbox**: Organizzazione flessibile dei contenuti
- **Responsive Design**: Adattamento automatico a diversi schermi

### 5. **Animazioni CSS**
- **Bounce**: Rimbalzo continuo
- **Rotate**: Rotazione infinita
- **Pulse**: Pulsazione ritmica
- **Slide**: Movimento laterale

### 6. **Sistema di Notifiche**
- **Toast Notifications**: Notifiche temporanee con animazioni di entrata
- **Auto-dismiss**: Rimozione automatica dopo 5 secondi
- **Tipi diversi**: Successo, Warning, Errore con colori specifici

## Tecniche CSS Utilizzate

### Gradiente e Colori
```css
background: linear-gradient(45deg, #667eea 0%, #764ba2 100%);
```

### Animazioni e Transizioni
```css
transition: all 0.3s ease;
animation: bounce 2s ease-in-out infinite;
```

### Effetti Glassmorphism
```css
background: rgba(255, 255, 255, 0.25);
backdrop-filter: blur(10px);
border: 1px solid rgba(255, 255, 255, 0.18);
```

### Layout Grid
```css
display: grid;
grid-template-areas: 
    "header header"
    "sidebar main"
    "footer footer";
```

### Hover Effects
```css
.btn:hover {
    transform: translateY(-2px);
    box-shadow: 0 6px 20px rgba(102, 126, 234, 0.6);
}
```

## Funzionalità Interattive

### 1. **Timer Counter**
Un contatore che si aggiorna automaticamente ogni secondo per dimostrare il binding dinamico.

### 2. **Progress Bar**
Barra di progresso animata con effetto "shine".

### 3. **Stato Loading**
Simulazione di caricamento con spinner CSS e cambio di stato del pulsante.

### 4. **Toggle Notifications**
Interruttore per attivare/disattivare le notifiche con feedback visivo.

### 5. **Notifiche Dinamiche**
Sistema completo di notifiche toast con:
- Animazioni di entrata
- Auto-dismiss programmato
- Chiusura manuale
- Diversi tipi (successo, warning, errore)

## Supporto Browser

Le tecniche utilizzate sono compatibili con:
- ? Chrome/Edge (tutte le versioni moderne)
- ? Firefox (versioni recenti)
- ? Safari (iOS 12+)
- ?? IE11 (supporto limitato per backdrop-filter e alcune animazioni)

## Responsive Design

La pagina include:
- **Mobile First**: Progettazione ottimizzata per dispositivi mobili
- **Breakpoints**: Adattamento automatico per tablet e desktop
- **Flex Layout**: Riorganizzazione degli elementi su schermi piccoli
- **Grid Responsive**: Layout grid che si adatta alla dimensione dello schermo

## Dark Mode Support

Implementato supporto per il tema scuro con:
```css
@media (prefers-color-scheme: dark) {
    /* Stili per tema scuro */
}
```

## File Correlati

- `Pages/HtmlCssDemo.razor` - Componente principale
- `wwwroot/css/html-css-demo.css` - Stili personalizzati
- `wwwroot/index.html` - Configurazione font per emoji e Unicode

## Obiettivi Didattici

Questa demo è progettata per insegnare:

1. **Separazione delle responsabilità**: HTML per struttura, CSS per presentazione, C# per logica
2. **CSS Moderno**: Utilizzo di Grid, Flexbox, animazioni e trasparenze
3. **UX Design**: Feedback visivo, animazioni fluide, stati di caricamento
4. **Responsive Design**: Adattamento a diversi dispositivi
5. **Accessibilità**: Utilizzo di ARIA labels e supporto tastiera
6. **Performance**: Animazioni GPU-accelerated e ottimizzazioni CSS

## Estensioni Possibili

La demo può essere estesa con:
- Temi multipli (light/dark/custom)
- Maggiori animazioni (fade, slide, zoom)
- Componenti più complessi (carousel, modal, dropdown)
- Integrazione con librerie CSS (Tailwind, Bulma)
- Progressive Web App features
- Supporto touch e gesture