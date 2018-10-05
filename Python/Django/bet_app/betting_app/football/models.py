from django.db import models
from django.contrib.auth.models import User
# Create your models here.

class League(models.Model):
    name = models.CharField(max_length=50)
    country = models.CharField(max_length=50)

    def __str__(self):
        return self.name

class Team(models.Model):
    name = models.CharField(max_length=50)
    logoUrl = models.CharField(max_length=100)
    current_points = models.PositiveSmallIntegerField(default=0)
    wins = models.PositiveSmallIntegerField(default=0)
    loses = models.PositiveSmallIntegerField(default=0)
    draws = models.PositiveSmallIntegerField(default=0)
    league = models.ForeignKey(League)

    def __str__(self):
        return self.name

class Match(models.Model):
    home_team = models.CharField(max_length=50)
    away_team = models.CharField(max_length=50)
    home_team_score = models.PositiveSmallIntegerField()
    away_team_score = models.PositiveSmallIntegerField()
    date = models.DateTimeField()
    home_team_coefficient = models.DecimalField(max_digits=3,decimal_places=3)
    away_team_coefficient = models.DecimalField(max_digits=3,decimal_places=3)
    status = models.CharField(max_length=20)  #get it from list
    league = models.ForeignKey(League)

    def __str__(self):
        return f"{self.home_team.name}-{self.away_team.name}"

class Player(models.Model):
    name = models.CharField(max_length=50)
    player_number = models.PositiveSmallIntegerField()
    position = models.CharField(max_length=50)
    imageUrl = models.CharField(max_length=100)
    team = models.ForeignKey(Team)

    def __str__(self):
        return self.name

class Bet(models.Model):
    author = models.ForeignKey(User)
    match = models.ForeignKey(Match)
    bet_money = models.PositiveIntegerField(default=10)
    is_open = models.BooleanField(default=True)


    def __str__(self):
        return self.author.name