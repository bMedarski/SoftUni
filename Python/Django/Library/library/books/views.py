from django.shortcuts import render
from django.http import HttpResponse
from django.views import generic
from .models import Book


class IndexView(generic.ListView):
    template_name = 'books/home.html'
    context_object_name = 'books'
    def get_queryset(self):
        return Book.objects.all()

class DetailView(generic.DetailView):
    model = Book
    template_name = 'books/book-detail.html'