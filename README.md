Voici la version mise à jour du **README.md** avec le lien vers l'APK Android. 🚀  

---

## **📌 README.md – ScanFlashLink v0.1.1**


# ScanFlashLink v0.1.1 🚀

**ScanFlashLink** est une application Windows qui reçoit des codes-barres scannés depuis une application Android et les envoie automatiquement dans la fenêtre en cours d'utilisation via un copier-coller (`Ctrl+V`).  

⚠️ **Téléchargez également l'APK Android correspondante** pour envoyer les codes vers l'application Windows :  
🔗 [ScanFlashLink - Application Android](https://github.com/rodrigueantunes/ScanFlashLink_Android)  

---

## **📜 Fonctionnalités**
✅ **Réception des codes-barres** depuis une application Android via TCP/IP  
✅ **Affichage des codes reçus** dans une interface simple (`txtLogs`)  
✅ **Copie automatique du code dans le presse-papiers**  
✅ **Collage (`Ctrl+V`) du code dans la fenêtre active**  
✅ **Ajout automatique d'un "Entrée" après le collage**  

---

## **📥 Installation**
### **🔹 Prérequis**
- **Windows 10 / 11**
- **.NET 8.0 Runtime**
- **Télécharger l'APK Android** : [ScanFlashLink_Android](https://github.com/rodrigueantunes/ScanFlashLink_Android)
- **Une application Android capable d'envoyer des codes-barres via TCP**

### **🔹 Cloner le projet**
```sh
git clone https://github.com/ton-utilisateur/ScanFlashLink.git
cd ScanFlashLink
```

### **🔹 Compilation**
Ouvrir le projet dans **Visual Studio** et compiler en **Release**.

### **🔹 Exécuter**
Lancer **ScanFlashLink.exe**, puis scanner un code-barres avec l'application Android connectée.

---

## **🛠️ Utilisation**
1️⃣ **Démarrer ScanFlashLink** sur Windows.  
2️⃣ **Installer et ouvrir l'APK Android** depuis [ScanFlashLink_Android](https://github.com/rodrigueantunes/ScanFlashLink_Android).  
3️⃣ **Configurer l'application Android** pour envoyer les codes vers l'adresse IP du PC sur le port `12345`.  
4️⃣ **Scanner un code-barres** avec l'application Android.  
5️⃣ **Le code est automatiquement collé dans la fenêtre active !** 🎉  

---

## **📦 Structure du projet**
```
📂 ScanFlashLink/
 ├── 📂 Assets/            # Icônes et ressources
 ├── 📂 Src/               # Code source de l'application
 ├── 📂 Bin/               # Fichiers compilés
 ├── 📂 Docs/              # Documentation
 ├── 📜 README.md          # Ce fichier
 ├── 📜 ScanFlashLink.sln  # Solution Visual Studio
```

---

## **📜 Journal des modifications – v0.1.1**
🆕 **Nouveautés :**
- **Correction** : Simulation clavier améliorée (remplacement de `SendKeys` par `Clipboard + Ctrl+V`).  
- **Amélioration** : Ajout automatique de la touche `Entrée` après la saisie.  
- **Refactoring** : Code optimisé pour .NET 8 et WPF.  
- **Ajout** : Lien vers l'APK Android correspondante.  

---

## **📩 Contact & Support**
📧 **Email** : contact@ton-site.com  
🐙 **GitHub** : [ton-utilisateur](https://github.com/ton-utilisateur)  
🚀 **Suggestions & issues** : Ouvrir un ticket sur [GitHub Issues](https://github.com/ton-utilisateur/ScanFlashLink/issues)  

---

## **📄 Licence**
📝 Ce projet est sous licence **MIT**. Vous êtes libre de le modifier et de le redistribuer.  

---

🚀 **Développement en cours !** Suivez le projet pour les prochaines mises à jour. 🎯  
```

---

## **📌 Résumé des ajouts**
✔ **Lien vers l'APK Android** ajouté en **haut du fichier** 📲  
✔ **Instructions pour télécharger et utiliser l'application Android**  
✔ **Journal des modifications mis à jour**  

---

🚀 **Maintenant, ton projet est totalement documenté et prêt à être publié !** 🔥  
Bonne publication sur **GitHub** ! 😊
