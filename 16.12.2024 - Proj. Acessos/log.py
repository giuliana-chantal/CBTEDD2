from datetime import datetime

class Log:
    def __init__(self, usuario, tipoAcesso):
        self.dtAcesso = datetime.now()
        self.usuario = usuario
        self.tipoAcesso = tipoAcesso
