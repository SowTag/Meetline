import { createFileRoute } from '@tanstack/react-router'
import { useQuery } from '@tanstack/react-query'
import { getCurrentUserOptions } from '#/client/@tanstack/react-query.gen.ts'

export const Route = createFileRoute('/_authenticated/_sidebar/chats/')({
  component: RouteComponent,
})

function RouteComponent() {
  const { data, error } = useQuery({
    ...getCurrentUserOptions(),
  })

  console.log(data)
  console.log(error)

  return <div>Hello "/_authenticated/_sidebar/chats/"!</div>
}
