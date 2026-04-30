window.scrollToBottom = () => {
    const terminal = document.querySelector('.terminal-container');
    if (terminal) {
        terminal.scrollTop = terminal.scrollHeight;
    }
};

window.detectMobile = () => {
    const userAgent = navigator.userAgent || navigator.vendor || window.opera;
    return /android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini/i.test(userAgent.toLowerCase());
};

// Manually start Blazor and handle startup failures
if (window.Blazor) {
    window.Blazor.start().catch(function (error) {
        console.error("Blazor failed to start:", error);
        const errorDiv = document.createElement('div');
        errorDiv.style.color = '#ff5555';
        errorDiv.style.padding = '20px';
        
        const h1 = document.createElement('h1');
        h1.textContent = 'Blazor failed to start';
        errorDiv.appendChild(h1);
        
        const pre = document.createElement('pre');
        pre.textContent = error.toString();
        errorDiv.appendChild(pre);

        const app = document.getElementById('app');
        if (app) app.appendChild(errorDiv);
    });
}
