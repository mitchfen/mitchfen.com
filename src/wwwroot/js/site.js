window.scrollToBottom = () => {
    const terminal = document.querySelector('.terminal-container');
    if (terminal) {
        terminal.scrollTop = terminal.scrollHeight;
    }
};

// Manually start Blazor and handle startup failures
if (window.Blazor) {
    window.Blazor.start().catch(function (error) {
        console.error("Blazor failed to start:", error);
        const errorDiv = document.createElement('div');
        errorDiv.style.color = '#ff5555';
        errorDiv.style.padding = '20px';
        errorDiv.innerHTML = '<h1>Blazor failed to start</h1><pre>' + error.toString() + '</pre>';
        const app = document.getElementById('app');
        if (app) app.appendChild(errorDiv);
    });
}
