Je vais frapper Bastien
Pas cool mec
Pas très malin de faire ça !!

ZombieFireball (voir dossier state Management Maxence):
Un zombie qui tire une boule de feu a distance, s'approche ou fui le joueur suivant la distance qui les separe
Cette ia est gérée sous un state Management divisé par plusieurs états :
Idle State:
verifie la distance qui separe le zombie du joueur.Suivant le resultat il passera au state 
Move (si le joueur est trop loin du zombie)
Running (si le joueur est trop près du zombie)
Attack (envoie une boule de feu si le joueur est a portée)

Move : 
S'approche du joueur si la distance les séparant est plus grande que la portée d'attaque
De ce state, on peut revenir au stade Idle si le joueur se trouve trop proche du zombie ou
au stade attack si on est a portée

Attack : 
Tire une boule de feu, attends 2 secondes, pour verifier s'il peut de nouveau tirer ou dans le cas contraire, revient au state Idle

Running : 
S'éloigne du joueur tant que la distance les séparant est trop petit, apres cela, il revient au state idle

Pour un schéma, voir l'image "Schéma StateManagement1"

ZombieRugby (voir dossier State Management Maxence Rugby):
Un zombie s'approchant du joueur, se met a charger s'il est à portée d'attaque puis fonce dans une direction (ne peut mettre a jour sa direction durant l'attaque) avant de reprendre sa poursuite 
Cette ia est gérée sous un state Management divisé par plusieurs états :

Idle :
verifie la distance qui separe le zombie du joueur.Suivant le resultat il passera au state 
Move (si le joueur est trop loin du zombie)
Attack (Se met a charger si le joueur est a portée)

Move : 
S'approche du joueur si la distance les séparant est plus grande que la portée d'attaque
De ce state, on peut revenir au stade Idle si le joueur se trouve trop proche du zombie ou
au stade attack si on est a portée

Attack :
Se met a charger son attaque (lance un grognement et ne bouge pas pendant X secondes)
Puis fonce vers le joueur sans changer de direction (le joueur peut donc l'esquiver)
Lancement d'un cooldown avant de continuer
Une fois le cooldown fini, le zombie repasse au state Idle

Pour un shéma, voir l'image "Schéma StateManagement Rugby"
