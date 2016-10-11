(function(){
  'use strict';
  
  function todoController(TodoService){
    var vm = this;

    vm.title = "To Do";

    vm.loadTodos = function(){
      TodoService.Get().then(
        function(results){
          vm.todos = results.data;
        },
        function(err){
          console.error(err);
        });
    };

    vm.addTodo = function(){
      TodoService.Save(vm.newTodo).then(
        function(result){
          vm.todos.push(result.data);
          vm.newTodo = { }
        },
        function(err){
          console.error(err);
        })
    };

    vm.markComplete = function(todo){
      TodoService.Save(todo).then(
        function(result){ 
          // do nothing 
        },
        function(err){
          console.error(err);
        })
    };

    vm.deleteTodo = function(todo){
      TodoService.Delete(todo.id).then(
        function(result){
          vm.todos.splice(vm.todos.indexOf(todo), 1);
        },
        function(err){
          console.error(err);
        }
      )
    };

    return vm;
  }

  angular.module('ToDoApp')
    .controller('TodoController', ['TodoService', todoController]);
}())